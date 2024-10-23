namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAppAdminStructNonAgWetlandsSqlQuires
{
    private readonly string _sqlCommand =
        @"  SELECT   [Id]
                            ,[ApplicationId]
                            ,[IsResidenceOnPresLand]
                            ,[ImprovRes]
                            ,[AreNonAgUses]
                            ,[NonAgExplan]
                            ,[IsFarmMarket]
                            ,[ImprovAg]
                            ,[WetlandsSurveyor]
                            ,[DateofDelineation]
                            ,[AcresofWetlands]
                            ,[AcresofTransitionArea]
                            ,[WetlandsClassification]
                            ,[LastUpdatedBy]
						    ,[LastUpdatedOn]
            FROM [Farm].[FarmEsmtAppAdminStructNonAgriWetlands]
            WHERE ApplicationId = @p_ApplicationId";


    public GetFarmEsmtAppAdminStructNonAgWetlandsSqlQuires()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
