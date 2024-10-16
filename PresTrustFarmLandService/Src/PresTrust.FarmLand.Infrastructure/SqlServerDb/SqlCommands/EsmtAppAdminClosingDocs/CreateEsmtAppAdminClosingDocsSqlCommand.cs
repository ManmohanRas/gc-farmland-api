namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public class CreateEsmtAppAdminClosingDocsSqlCommand

    {
        private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmEsmtAppAdminClosingDocStatus]
						(
                             ApplicationId
                            ,ProjectStatus
                            ,EPDeedBook
                            ,EPDeedPage
                            ,EPDeedFiled
                            ,EPDeedClerkID
                            ,CountyAttorney
                            ,CountyAttorneyInfo
                            ,SurveyDate
                            ,Surveyor
                            ,TitleCompany
                            ,TitlePolicy
                            ,ClosingDate
                            ,EndorsementDates
                            ,LastUpdatedBy
                            ,LastUpdatedOn
                        )
                        VALUES
                        (
                             @p_ApplicationId
                            ,@p_ProjectStatus
                            ,@p_EPDeedBook
                            ,@p_EPDeedPage
                            ,@p_EPDeedFiled
                            ,@p_EPDeedClerkID
                            ,@p_CountyAttorney
                            ,@p_CountyAttorneyInfo
                            ,@p_SurveyDate
                            ,@p_Surveyor
                            ,@p_TitleCompany
                            ,@p_TitlePolicy
                            ,@p_ClosingDate
                            ,@p_EndorsementDates
                            ,@p_LastUpdatedBy
                            ,GETDATE()	
                        );
                        SELECT CAST( SCOPE_IDENTITY() AS INT);";

        public CreateEsmtAppAdminClosingDocsSqlCommand()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
