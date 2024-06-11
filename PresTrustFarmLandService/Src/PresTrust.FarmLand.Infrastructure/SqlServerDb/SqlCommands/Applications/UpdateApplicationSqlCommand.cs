namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands.Applications
{
    public class UpdateApplicationSqlCommand
    {
        private readonly string _sqlCommand =
        @" UPDATE [Flood].[FloodApplication]
               SET
                        [Title] = @p_Title,
                        [AgencyId] = @p_AgencyId,
                        [ApplicationTypeId] = @p_ApplicationTypeId,
                        [LastUpdatedBy] = @p_LastUpdatedBy,
                        [LastUpdatedOn] = GetDate()
               WHERE    [Id] = @p_ApplicationId;";

        public UpdateApplicationSqlCommand() { }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
