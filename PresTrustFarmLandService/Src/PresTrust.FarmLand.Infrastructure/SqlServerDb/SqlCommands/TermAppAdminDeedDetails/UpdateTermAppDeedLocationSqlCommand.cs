namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public class UpdateTermAppDeedLocationSqlCommand
    {
        private readonly string _sqlCommand =
         @" UPDATE [Farm].[FarmTermAppDeedLocation]
                SET
                    IsChecked = @p_IsChecked
            WHERE	ApplicationId = @p_ApplicationId AND ParcelId = @p_ParcelId;";

        public UpdateTermAppDeedLocationSqlCommand()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
