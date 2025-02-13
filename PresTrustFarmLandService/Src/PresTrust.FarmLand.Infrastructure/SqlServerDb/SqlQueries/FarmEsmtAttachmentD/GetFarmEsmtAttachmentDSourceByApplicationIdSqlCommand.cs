namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAttachmentDSourceByApplicationIdSqlCommand
{
       private readonly string _sqlCommand =
             @"SELECT  FSA.Id AS  EquineActivityTypeId
                      ,FD.Id
                    , FD.ApplicationId
                    , FD.Counts
                    , FD.Number
                    , FD.NumberOfHorses
                    , FD.NumberOfHorsesActivity
                    , FD.NumberOfStalls
                    , FD.RunInSheds
                    , FD.IndoorRidingArena
                    , FD.OutdoorRidingArena
                  FROM [Farm].[FarmEsmtAttachmentDActivityType] FSA
                    LEFT JOIN [Farm].[FarmEsmtAttachmentD] FD ON (FD.[ApplicationId] = @p_ApplicationId AND  FSA.Id = FD.EquineActivityTypeId);";
    
        public GetFarmEsmtAttachmentDSourceByApplicationIdSqlCommand()
        {
        }
        public override string ToString()
        {
            return _sqlCommand;
        }
 } 