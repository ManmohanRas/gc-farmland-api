namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminAppraisalReportCommandMappingProfile :Profile
    {
        public SaveEsmtAppAdminAppraisalReportCommandMappingProfile()
        {
            CreateMap<SaveEsmtAppAdminAppraisalReportCommand, FarmEsmtAppAdminAppraisalReportEntity>();
        }
    }
}