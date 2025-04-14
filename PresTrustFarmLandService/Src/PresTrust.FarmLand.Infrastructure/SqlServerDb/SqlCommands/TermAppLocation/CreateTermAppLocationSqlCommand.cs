namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermAppLocationSqlCommand
{
    private readonly string _sqlCommand =
           @"INSERT INTO [Farm].[FarmAppLocationDetails]
						(
							 ApplicationId
							,FarmListID
							,ParcelId	
							,PamsPin
							,IsChecked
							,AcresToBeAcquired
							,ExceptionAreaAcres
							,Notes
							,Acres
							,ExceptionArea
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_FarmListID
							,@p_ParcelId	
							,@p_PamsPin
							,@p_IsChecked
							,@p_AcresToBeAcquired
							,@p_ExceptionAreaAcres
							,@p_Notes
							,@p_Acres
							,@p_ExceptionArea
						);";

    public CreateTermAppLocationSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}


