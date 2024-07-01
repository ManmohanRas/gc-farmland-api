

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public  class UpdateSiteCharacteristicsSqlCommand
{
    private string _sqlCommand =
        @"
          UPDATE [Farm].[FarmTermAppSiteCharacteristics]

          SET  
                        [Id]                            =@P_Id
                        [ApplicationId]                 = @P_ApplicationId,
                       [Area]                          = @P_Area,
                       [LandUse]                       = @P_LandUse,         
                        [Cropland]                      = @PCropland,                      
                        [Woodland]                      = @P_Woodland
                        [Pasture]                       = @P_Pasture,                   
                        [Orchard]                       = @P_Orchard,  
                       [Other]                         = @P_Other,
                        [EasementOrRightOfway]          = @P_EasementOrRightOfway,                            
                        [NoteEasementOrRightOfway]      = @P_NoteEasementOrRightOfway,                    
                        [MortgageLiens]                 = @P_MortgageLiens,                 
                        [NoteMortgageLiens]             = @P_NoteMortgageLiens,                    
                      
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId"";
        

        ";

    public UpdateSiteCharacteristicsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }


}
