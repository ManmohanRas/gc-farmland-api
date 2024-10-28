namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAppAdminStructNonAgWetlandsSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands]
                      SET    ApplicationId             = @p_ApplicationId            
                            ,IsResidenceOnPresLand     = @p_IsResidenceOnPresLand
                            ,ImprovRes                 = @p_ImprovRes
                            ,AreNonAgUses              = @p_AreNonAgUses
                            ,NonAgExplan               = @p_NonAgExplan
                            ,IsFarmMarket              = @p_IsFarmMarket
                            ,ImprovAg                  = @p_ImprovAg
                            ,WetlandsSurveyor          = @p_WetlandsSurveyor
                            ,DateofDelineation         = @p_DateofDelineation
                            ,AcresofWetlands           = @p_AcresofWetlands
                            ,AcresofTransitionArea     = @p_AcresofTransitionArea
                            ,WetlandsClassification    = @p_WetlandsClassification
                            ,LastUpdatedBy             = @p_LastUpdatedBy
						    ,LastUpdatedOn             = @p_LastUpdatedOn
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateFarmEsmtAppAdminStructNonAgWetlandsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
