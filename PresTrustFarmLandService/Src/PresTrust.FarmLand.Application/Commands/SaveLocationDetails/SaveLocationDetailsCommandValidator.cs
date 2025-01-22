namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommandValidator: Profile
{
    public SaveLocationDetailsCommandValidator()
    {
        CreateMap<SaveBlockLot, FarmAppLocationDetailsEntity>();
    }
}
