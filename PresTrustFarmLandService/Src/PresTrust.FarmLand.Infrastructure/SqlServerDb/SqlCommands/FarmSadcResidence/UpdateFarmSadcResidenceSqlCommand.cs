namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmSadcResidenceSqlCommand
{
    private readonly string _sqlCommand =
 @" UPDATE [Farm].[FarmEsmtSadcResidence]
            SET              ApplicationId           = @p_ApplicationId
                            ,IsAgriculturalLabor     = @p_IsAgriculturalLabor
                            ,UnitsUsedForLabor       = @p_UnitsUsedForLabor
                            ,Occupants               = @p_Occupants
                            ,MonthsOccupied          = @p_MonthsOccupied
                            ,IsOccupantsWork         = @p_IsOccupantsWork
                            ,PleaseExplain           = @p_PleaseExplain
                            ,IsResidencesRented      = @p_IsResidencesRented
                            ,RDSOsReserve            = @p_RDSOsReserve
                            ,ExcepAcres1             = @p_ExcepAcres1
                            ,NonSeverable1           = @p_NonSeverable1
                            ,Severable1              = @p_Severable1
                            ,AdditionalComment1      = @p_AdditionalComment1
                            ,ExcepAcres2             = @p_ExcepAcres2
                            ,NonSeverable2           = @p_NonSeverable2
                            ,Severable2              = @p_Severable2
                            ,AdditionalComment2      = @p_AdditionalComment2
                            ,EsmtOthersText          = @p_EsmtOthersText
                            ,IsSightTriangle           = @p_IsSightTriangle
                            ,LastUpdatedBy           = @p_LastUpdatedBy
                            ,LastUpdatedOn           = @p_LastUpdatedOn
                 WHERE Id = @p_Id AND ApplicationId  = @p_ApplicationId;";

    public UpdateFarmSadcResidenceSqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}

