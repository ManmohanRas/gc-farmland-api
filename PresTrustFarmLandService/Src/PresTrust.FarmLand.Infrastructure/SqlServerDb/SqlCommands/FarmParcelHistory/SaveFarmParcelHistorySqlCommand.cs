namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class SaveFarmParcelHistorySqlCommand
{
    private readonly string _sqlCommand =
                    @"  INSERT INTO [Farm].[FarmParcelHistory]
						(
							ParcelId,
							CurrentPamsPin,
							PreviousPamsPin,
							ReasonForChange,
							ChangeType,
							LastUpdatedBy,
							LastUpdatedOn
						)
						VALUES
						(
							@p_ParcelId,
							@p_CurrentPamsPin,
							@p_PreviousPamsPin,
							@p_ReasonForChange,
							@p_ChangeType,
							@p_LastUpdatedBy,
							GetDate()
						)

						SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public SaveFarmParcelHistorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
