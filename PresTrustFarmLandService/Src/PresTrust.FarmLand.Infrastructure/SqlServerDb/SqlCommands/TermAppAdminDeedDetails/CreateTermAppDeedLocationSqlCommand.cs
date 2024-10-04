namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public  class CreateTermAppDeedLocationSqlCommand
    {
        private readonly string _sqlCommand =
          @"INSERT INTO [Farm].[FarmTermAppDeedLocation]
						(
							 ApplicationId
							,ParcelId
							,DeedId
							,IsChecked
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_ParcelId	
							,@p_DeedId
							,@p_IsChecked
						);";



        public CreateTermAppDeedLocationSqlCommand() { 
        }
        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
