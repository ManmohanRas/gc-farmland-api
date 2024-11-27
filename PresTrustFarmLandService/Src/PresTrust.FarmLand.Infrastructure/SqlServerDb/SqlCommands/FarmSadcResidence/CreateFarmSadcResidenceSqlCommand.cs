namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmSadcResidenceSqlCommand
{
    private readonly string _sqlCommand =
             @"INSERT INTO [Farm].[FarmEsmtSadcResidence]
						(
                             ApplicationId
                            ,IsAgriculturalLabor
                            ,UnitsUsedForLabor
                            ,Occupants
                            ,MonthsOccupied
                            ,IsOccupantsWork
                            ,PleaseExplain
                            ,IsResidencesRented
                            ,RDSOsReserve
                            ,ExcepAcres1
                            ,NonSeverable1
                            ,Severable1
                            ,AdditionalComment1
                            ,ExcepAcres2
                            ,NonSeverable2
                            ,Severable2
                            ,AdditionalComment2
                            ,EsmtOthersText
                            ,IsSightTriangle
                            ,LastUpdatedBy
                            ,LastUpdatedOn
                        )
                        VALUES
                        (
                             @p_ApplicationId
                            ,@p_IsAgriculturalLabor
                            ,@p_UnitsUsedForLabor
                            ,@p_Occupants
                            ,@p_MonthsOccupied
                            ,@p_IsOccupantsWork
                            ,@p_PleaseExplain
                            ,@p_IsResidencesRented
                            ,@p_RDSOsReserve
                            ,@p_ExcepAcres1
                            ,@p_NonSeverable1
                            ,@p_Severable1
                            ,@p_AdditionalComment1
                            ,@p_ExcepAcres2
                            ,@p_NonSeverable2
                            ,@p_Severable2
                            ,@p_AdditionalComment2
                            ,@p_EsmtOthersText
                            ,@p_IsSightTriangle
                            ,@p_LastUpdatedBy
                            ,GETDATE()	
                        );
                        SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmSadcResidenceSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
