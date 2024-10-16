namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public class UpdateEsmtAppAdminClosingDocsSqlCommand
    {
         private readonly string _sqlCommand =
       @" UPDATE [Farm].[FarmEsmtAppAdminClosingDocStatus]
            SET              ApplicationId          = @p_ApplicationId
                            ,ProjectStatus          = @p_ProjectStatus
                            ,EPDeedBook             = @p_EPDeedBook
                            ,EPDeedPage             = @p_EPDeedPage
                            ,EPDeedFiled            = @p_EPDeedFiled
                            ,EPDeedClerkID          = @p_EPDeedClerkID
                            ,CountyAttorney         = @p_CountyAttorney
                            ,CountyAttorneyInfo     = @p_CountyAttorneyInfo
                            ,SurveyDate             = @p_SurveyDate
                            ,Surveyor               = @p_Surveyor
                            ,TitleCompany           = @p_TitleCompany
                            ,TitlePolicy            = @p_TitlePolicy
                            ,ClosingDate            = @p_ClosingDate
                            ,EndorsementDates       = @p_EndorsementDates
                            ,LastUpdatedBy          = @p_LastUpdatedBy
                            ,LastUpdatedOn          = @p_LastUpdatedOn
                 WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

        public UpdateEsmtAppAdminClosingDocsSqlCommand()
        { }


        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
