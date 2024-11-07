
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
                 [IsEasement], 
                 [IsRightOfway],
                 [NoteEasementRightOfway],
                 [IsMortgage],
                 [IsLiens],
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
                       @p_IsEasement,
                       @p_IsRightOfway,
                       @p_NoteEasementRightOfway,
                       @p_IsMortgage,
                       @p_IsLiens,
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
