namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAttachmentDSourceSqlCommand
{
    private readonly string _sqlCommand =
   @"INSERT INTO [Farm].[FarmEsmtAttachmentD]
            (
              ApplicationId
            ,EquineActivityTypeId
            ,Counts
            ,Number
            ,NumberOfHorses
            ,NumberOfHorsesActivity
            ,NumberOfStalls
            ,RunInSheds
            ,IndoorRidingArena
            ,OutdoorRidingArena
            ,LastUpdatedBy
            ,LastUpdatedOn)
            VALUES
            (
            @p_ApplicationId
            ,@p_EquineActivityTypeId
            ,@p_Counts
            ,@p_Number
            ,@p_NumberOfHorses
            ,@p_NumberOfHorsesActivity
            ,@p_NumberOfStalls
            ,@p_RunInSheds
            ,@p_IndoorRidingArena
            ,@p_OutdoorRidingArena
            ,@p_LastUpdatedBy
            ,@p_LastUpdatedOn
             );
        SELECT CAST(SCOPE_IDENTITY() AS INT);";
    public CreateFarmEsmtAttachmentDSourceSqlCommand()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}