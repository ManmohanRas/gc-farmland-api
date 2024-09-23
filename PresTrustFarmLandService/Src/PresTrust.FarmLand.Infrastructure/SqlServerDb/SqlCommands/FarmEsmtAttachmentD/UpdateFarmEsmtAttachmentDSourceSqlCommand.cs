namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
    public class UpdateFarmEsmtAttachmentDSourceSqlCommand
    {
        private readonly string _sqlCommand =
        @"UPDATE [Farm].[FarmEsmtAttachmentD]
            SET 
             EquineActivityTypeId = @P_EquineActivityTypeId
            ,Counts = @P_Counts
            ,Number = @P_Number
            ,NumberOfHorses = @P_NumberOfHorses
            ,NumberOfHorsesActivity = @P_NumberOfHorsesActivity
            ,NumberOfStalls = @P_NumberOfStalls
            ,RunInSheds = @P_RunInSheds
            ,IndoorRidingArena = @P_IndoorRidingArena
            ,OutdoorRidingArena = @P_OutdoorRidingArena
            ,LastUpdatedBy = @P_LastUpdatedBy
            ,LastUpdatedOn = @P_LastUpdatedOn
            WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";
        public UpdateFarmEsmtAttachmentDSourceSqlCommand()
        {

        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }

