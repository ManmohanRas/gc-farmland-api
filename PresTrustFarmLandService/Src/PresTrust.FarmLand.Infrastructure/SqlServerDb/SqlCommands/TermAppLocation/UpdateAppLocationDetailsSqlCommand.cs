namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateLocationDetailsSqlCommand
{
	private readonly string _sqlCommand =
           @"UPDATE [Farm].[FarmAppLocationDetails] SET
						
							 ApplicationId = @p_ApplicationId
							,FarmListID = @p_FarmListID
							,PamsPin   =  @p_PamsPin
							,IsChecked = @p_IsChecked
                            ,ParcelId = @p_ParcelId
							,AcresToBeAcquired = @p_AcresToBeAcquired
							,ExceptionAreaAcres = @p_ExceptionAreaAcres
							,Notes = @p_Notes
							,Acres = @p_Acres
							,ExceptionArea = @p_ExceptionArea
						
					WHERE ParcelId =@p_ParcelId ;";

	public UpdateLocationDetailsSqlCommand() { }

	public override string ToString()
	{
		return _sqlCommand;
	}
}
