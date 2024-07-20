namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermAppLocationSqlCommand
{
    private readonly string _sqlCommand =
           @"INSERT INTO [Farm].[FarmTermAppLocation]
						(
							 ApplicationId
							,FarmListID
							,ParcelId	
							,PamsPin
							,IsChecked
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_FarmListID
							,@p_ParcelId	
							,@p_PamsPin
							,@p_IsChecked
						);";

    public CreateTermAppLocationSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
