namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtLiensCommandMappingProfile : Profile
    {
        public SaveEsmtLiensCommandMappingProfile()
        {
            CreateMap<SaveEsmtLiensCommand, EsmtOwnerDetailsEntity>();
        }
    }
}
