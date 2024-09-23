using System;

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
                      

    //SELECT FF.Id
    //               , FS.Id AS FundingSourceTypeId
    //               , FF.ApplicationId
    //               , CASE WHEN FS.Id< 7 THEN FS.Title
    //                WHEN FS.Id = 7 THEN FF.Title
    //                ELSE FF.Title
    //                END AS Title
    //               , FF.Amount
    //               , FF.AwardDate
    //                FROM[Flood].[FloodApplicationFundingSourceType] FS
    //                LEFT JOIN [Flood].[FloodApplicationFinanceFund] FF ON (FF.ApplicationId = @p_ApplicationId AND FS.Id = FF.FundingSourceTypeId);";
        public GetFarmEsmtAttachmentDSourceByApplicationIdSqlCommand()
        {
        }
        public override string ToString()
        {
            return _sqlCommand;
        }
 } 