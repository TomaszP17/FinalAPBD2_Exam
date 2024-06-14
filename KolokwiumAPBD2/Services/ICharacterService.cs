using KolokwiumAPBD2.RequestModels;
using KolokwiumAPBD2.ResponseModels;

namespace KolokwiumAPBD2.Services;

public interface ICharacterService
{
    Task<GetCharacterResponseModel> GetCharacterByIdAsync(int id);
    Task<List<PostBackPackSlotResponseModel>> AddProductsToBackPack(CreateBackPackRequestModel model, int id);
}