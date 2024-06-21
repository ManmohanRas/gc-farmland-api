namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateApplicationSqlCommand
{
    private readonly string _sqlCommand =
    @" INSERT INTO [Farm].[FarmApplication]
               (
                [Title]
               ,[AgencyId]
               ,[FarmListId]
               ,[ApplicationTypeId]
               ,[StatusId]
               ,[CreatedByProgramUser]
               ,[IsApprovedByMunicipality]
               ,[CreatedBy]
               ,[CreatedOn] 
               ,[LastUpdatedBy]
               ,[LastUpdatedOn]
               )
            VALUES
               (
                @p_Title
               ,@p_AgencyId
               ,@p_FarmListId
               ,@p_ApplicationTypeId
               ,@p_StatusId
               ,@p_CreatedByProgramUser
               ,@p_IsApprovedByMunicipality
               ,@p_CreatedBy
               ,GETDATE()
               ,@p_LastUpdatedBy
               ,GETDATE()
               );
             SELECT CAST(SCOPE_IDENTITY() AS INT);";

    public CreateApplicationSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
