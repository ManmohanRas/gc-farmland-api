namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
	public class CreateTermAppAdminDetailsSqlCommand
	{
		private readonly string _sqlCommand =
				@"INSERT INTO [Farm].[FarmTermAppAdminDetails]
						(
							 ApplicationId
							,SADCId						
							,MaxGrant						
							,PermanentlyPreserved			
							,MunicipallyApproved			
							,EnrollmentDate				
							,RenewalDate					
							,ExpirationDate				
							,RenewalExpirationDate
							,Comment
							,LastUpdatedBy  
							,LastUpdatedOn	
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_SADCId						
							,@p_MaxGrant						
							,@p_PermanentlyPreserved			
							,@p_MunicipallyApproved			
							,@p_EnrollmentDate				
							,@p_RenewalDate					
							,@p_ExpirationDate				
							,@p_RenewalExpirationDate
							,@p_Comment
							,@p_LastUpdatedBy  
							,GETDATE()	
						);

			SELECT CAST( SCOPE_IDENTITY() AS INT);";

		public CreateTermAppAdminDetailsSqlCommand()
		{
		}

		public override string ToString()
		{
			return _sqlCommand;
		}
	}
}
