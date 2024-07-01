
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateSiteCharacteristicsSqlCommand
{

    private readonly string _sqlCommand =
        @"
           INSERT INTO [Farm].[FarmTermAppSiteCharacteristics]
         (
                 [Id] ,
                 [ApplicationId],
                 [Area],
                 [LandUse],
                 [Cropland],
                 [Woodland],
                 [Pasture],
                 [Orchard],
                 [Other],
                 [EasementOrRightOfway],
                 [NoteEasementOrRightOfway],
                 [MortgageLiens],
                 [NoteMortgageLiens] 
         )
         VALUES
                       (@p_Id
                       ,@p_ApplicationId
                       ,@p_Area
                       ,@p_LandUse
                       ,@p_Cropland
                       ,@p_Woodland
                       ,@p_Pasture
                       ,@p_Orchard 
                       ,@p_Other
                       ,@p_EasementOrRightOfway
                       ,@p_NoteEasementOrRightOfway
                       ,@p_NoteMortgageLiens
                       )
                    SELECT CAST( SCOPE_IDENTITY() AS INT);


        ";

    public CreateSiteCharacteristicsSqlCommand() { }


    public override string ToString()
    {
        return _sqlCommand;
    }


}
