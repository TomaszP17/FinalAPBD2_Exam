using KolokwiumAPBD2.Contexts;
using KolokwiumAPBD2.Endpoints;
using KolokwiumAPBD2.Exceptions;
using KolokwiumAPBD2.Models;
using KolokwiumAPBD2.RequestModels;
using KolokwiumAPBD2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD2.Services;

public class CharacterService(DatabaseContext context) : ICharacterService
{
    public async Task<GetCharacterResponseModel> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters
            .Where(c => c.CharacterId == id)
            .Select(c => new GetCharacterResponseModel
            {
               FirstName = c.FirstName,
               LastName = c.LastName,
               CurrentWeight = c.CurrentWeight,
               MaxWeight = c.MaxWeight,
               Money = c.Money,
               BackPackSlots = c.BackPackSlots
                   .Where(bp => bp.CharacterId == id)
                   .Select(bp => new GetBackPackSlotResponseModel
                   {
                       SlotId = bp.BackPackSlotId,
                       ItemName = bp.Item.Name,
                       ItemWeight = bp.Item.Weight
                   }).ToList(),
               Titles = c.CharacterTitles
                   .Where(ct => ct.CharacterId == id)
                   .Select(ct => new GetTitleResponseModel
                   {
                       Title = ct.Title.Name,
                       AquiredAt = ct.AcquiredAt
                   }).ToList()
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Character with that id:{id} is not exists");
        }

        return result;
    }

    public async Task<List<PostBackPackSlotResponseModel>> AddProductsToBackPack(CreateBackPackRequestModel model, int id)
    {
        var character = await context.Characters.FirstOrDefaultAsync(c => c.CharacterId == id);

        if (character is null)
        {
            throw new NotFoundCharacterException($"Character with that id: {id} is not found");
        }
        
        var items = await context.Items
            .Where(i => model.ItemsId.Any(ii => i.ItemId == ii))
            .Select(i => i.ItemId).ToListAsync();
        
        model.ItemsId.ForEach(i =>
        {
            if (!items.Contains(i))
            {
                throw new NotFoundException($"Item with that id: {id} is not found");
            }
        });
        var sumOfWeight = 0;
        var itemsList = new List<Item>();
        
        foreach (var itemId in items)
        {
            var item = await context.Items.Where(i => i.ItemId == itemId).FirstOrDefaultAsync();
            itemsList.Add(item);
            sumOfWeight += item.Weight;
        }
        
        if (sumOfWeight > character.MaxWeight - character.CurrentWeight)
        {
            throw new NotEnoughWeightException("This character has not enough space");
        }

        character.CurrentWeight += sumOfWeight;
        var backPackSlots = new List<PostBackPackSlotResponseModel>();
        
        foreach (var item in itemsList)
        {
            var newBackPack = new BackPackSlot
            {
                CharacterId = id,
                ItemId = item.ItemId
            };
            await context.BackPackSlots.AddAsync(newBackPack);
            await context.SaveChangesAsync();
            
            backPackSlots.Add(new PostBackPackSlotResponseModel
            {
                CharacterId = id,
                ItemId = item.ItemId,
                SlotId = newBackPack.BackPackSlotId
            });
        }
        return backPackSlots;
    }
}