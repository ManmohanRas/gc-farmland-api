namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateFarmEsmtAppAdminStructNonAgWetlandsSqlCommand
{
    private readonly string _sqlCommand =
                @"INSERT INTO [Farm].[FarmEsmtAppAdminStructNonAgriWetlands]
                     (
                             ApplicationId
                            ,IsResidenceOnPresLand
                            ,ImprovRes
                            ,AreNonAgUses
                            ,NonAgExplan
                            ,IsFarmMarket
                            ,ImprovAg
                            ,WetlandsSurveyor
                            ,DateofDelineation
                            ,AcresofWetlands
                            ,AcresofTransitionArea
                            ,WetlandsClassification
                            ,LastUpdatedBy  
						    ,LastUpdatedOn
                     )
              
                     VALUES
                     (
                             @p_ApplicationId
                            ,@p_IsResidenceOnPresLand
                            ,@p_ImprovRes
                            ,@p_AreNonAgUses
                            ,@p_NonAgExplan
                            ,@p_IsFarmMarket
                            ,@p_ImprovAg
                            ,@p_WetlandsSurveyor
                            ,@p_DateofDelineation
                            ,@p_AcresofWetlands
                            ,@p_AcresofTransitionArea
                            ,@p_WetlandsClassification
                            ,@p_LastUpdatedBy  
						    ,GETDATE()
                     );
                 SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtAppAdminStructNonAgWetlandsSqlCommand()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
