namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetEsmtAppAdminClosingDocsSqlQuery
    {

        private readonly string _sqlCommand =
      @"  SELECT	     Id							
						,ApplicationId					
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
			FROM [Farm].[FarmEsmtAppAdminClosingDocStatus]
            WHERE ApplicationId = @p_ApplicationId";

        public GetEsmtAppAdminClosingDocsSqlQuery()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
