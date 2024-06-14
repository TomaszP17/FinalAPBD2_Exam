using KolokwiumAPBD2.Exceptions;
using KolokwiumAPBD2.RequestModels;
using KolokwiumAPBD2.Services;

namespace KolokwiumAPBD2.Endpoints;

public static class CharactersEndpoints
{
    public static void RegisterCharactersEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("characters");
        
        group.MapGet("{characterId:int}", async (int characterId, ICharacterService service) =>
        {
            try
            {
                return Results.Ok(await service.GetCharacterByIdAsync(characterId));
            }
            catch (NotFoundException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
        
        group.MapPost("{characterId:int}/backpackslots", async (
            int characterId,
            CreateBackPackRequestModel data,
            ICharacterService service) =>
        {
            if (data.ItemsId.Count <= 0)
            {
                return Results.BadRequest("Array must have at least 1 element");
            }
            
            try
            {
                var backpacks = await service.AddProductsToBackPack(data, characterId);
                return Results.Created($"/{backpacks}", backpacks);
            }
            catch (NotFoundException e)
            {
                return Results.BadRequest(e.Message);
            }
            catch (NotFoundCharacterException e)
            {
                return Results.BadRequest(e.Message);
            }
            catch (NotEnoughWeightException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}