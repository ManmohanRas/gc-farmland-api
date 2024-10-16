namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminClosingDocsCommandMappingProfile : Profile
    {
        public SaveEsmtAppAdminClosingDocsCommandMappingProfile()
        {
            CreateMap<SaveEsmtAppAdminClosingDocsCommand, FarmEsmtAppAdminClosingDocsEntity>();
        }
    }
}
