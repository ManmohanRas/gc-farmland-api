
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateSiteCharacteristicsSqlCommand
{

    private readonly string _sqlCommand =
        @"
           INSERT INTO [Farm].[FarmTermAppSiteCharacteristics]
         (
                 [ApplicationId],
                 [Area],
                 [LandUse],
                 [Cropland],
                 [Woodland],
                 [Pasture],
                 [Orchard],
                 [Other],
                 [EasementRightOfway],
                 [NoteEasementRightOfway],
                 [MortgageLiens],
                 [NoteMortgageLiens],
                 [LastUpdatedBy],
                 [LastUpdatedOn]
                 
         )
         VALUES
                       (@p_ApplicationId,
                       @p_Area,
                       @p_LandUse,
                       @p_CropLand,
                       @p_WoodLand,
                       @p_Pasture,
                       @p_Orchard ,
                       @p_Other,
                       @p_EasementRightOfway,
                       @p_NoteEasementRightOfway,
                       @p_MortgageLiens,
                       @p_NoteMortgageLiens,
                       @p_LastUpdatedBy,
                        GETDATE()
                       );
                    SELECT CAST( SCOPE_IDENTITY() AS INT);


        ";

    public CreateSiteCharacteristicsSqlCommand() { }


    public override string ToString()
    {
        return _sqlCommand;
    }


}
