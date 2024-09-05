namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
        @"  SELECT  Id
                   ,ApplicationId
                   ,AmountPerAcre
				   ,Designation
				   ,Title	
				   ,SignedOn
				   ,LastUpdatedBy  
				   ,LastUpdatedOn	
            FROM [Farm].[FarmEsmtAppSignatory]
            WHERE ApplicationId = @p_ApplicationId";


    public GetEsmtAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
