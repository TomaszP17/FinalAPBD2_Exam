namespace KolokwiumAPBD2.ResponseModels;

public class GetCharacterResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public int Money { get; set; }
    public List<GetBackPackSlotResponseModel> BackPackSlots { get; set; }
    public List<GetTitleResponseModel> Titles { get; set; }
}