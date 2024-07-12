namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmSqlCommand
{
    private readonly string _sqlCommand =
            @"INSERT INTO [Farm].[FarmList]
                     (
                       [FarmNumber]
                      ,[FarmName]
                      ,[Status]
                      ,[AgencyID]
                      ,[OriginalLandowner]
                      ,[Address1]
                      ,[Address2]
                      )
			  VALUES
			  (  
                      @p_FarmNumber,
                      @p_FarmName,
                      @p_Status,                      
                       @p_AgencyID,                        
                       @p_OriginalLandowner,   
                       @p_Address1,
                      @p_Address2
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
