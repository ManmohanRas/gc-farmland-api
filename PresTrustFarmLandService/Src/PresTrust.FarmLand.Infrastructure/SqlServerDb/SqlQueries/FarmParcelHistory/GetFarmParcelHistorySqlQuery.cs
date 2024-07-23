namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmParcelHistorySqlQuery
{
    private readonly string _sqlCommand =
      @"   SELECT       [Id],
	                    [CurrentPamsPin],
	                    [PreviousPamsPin],
	                    [ChangeType],
	                    [ReasonForChange],
	                    [LastUpdatedOn]
            FROM        [Farm].[FarmParcelHistory]
            WHERE       [ParcelId] = @p_ParcelId
            ORDER BY    [LastUpdatedOn] DESC;"
      ;
    public GetFarmParcelHistorySqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
