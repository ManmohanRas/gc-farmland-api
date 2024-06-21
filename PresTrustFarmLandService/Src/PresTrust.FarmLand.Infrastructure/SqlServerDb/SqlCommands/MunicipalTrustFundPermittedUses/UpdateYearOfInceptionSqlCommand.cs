namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateYearOfInceptionSqlCommand
{
    private readonly string _sqlCommand =
    @"UPDATE [Farm].[FarmMunicipalTrustFundPermittedUses]
                     SET  [YearOfInception]            = @p_YearOfInception
             WHERE AgencyId = @p_AgencyId;";

    public UpdateYearOfInceptionSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
