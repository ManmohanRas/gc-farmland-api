namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands.Applications
{
    public class CreateApplicationSqlCommand
    {
        private readonly string _sqlCommand =
        @" INSERT INTO [Flood].[FloodApplication]
               (
                [Title]
               ,[AgencyId]
               ,[ApplicationTypeId]
               ,[StatusId]
               ,[CreatedByProgramAdmin]
               ,[LastUpdatedBy]
               ,[LastUpdatedOn]
               )
            VALUES
               (
                @p_Title
               ,@p_AgencyId
               ,@p_ApplicationTypeId
               ,@p_ApplicationSubTypeId
               ,@p_StatusId
               ,@p_CreatedByProgramAdmin
               ,@p_LastUpdatedBy
               ,GetDate()
               );
             SELECT CAST(SCOPE_IDENTITY() AS INT);";

        public CreateApplicationSqlCommand() { }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
