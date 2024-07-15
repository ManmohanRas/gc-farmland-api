namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmSqlCommand
{
    private readonly string _sqlCommand =
                @"UPDATE  [Farm].[FarmList]
                 SET
                       [FarmName] = @p_FarmName
                      ,[Status] = @p_Status
                      ,[AgencyID] = @p_AgencyID
                      ,[OriginalLandowner] = @p_OriginalLandowner
                      ,[Address1] = @p_Address1
                      ,[Address2] = @p_Address2
                      ,[FarmNumber] = @p_FarmNumber
                      WHERE  FarmListID = @p_FarmListID";

    public UpdateFarmSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
