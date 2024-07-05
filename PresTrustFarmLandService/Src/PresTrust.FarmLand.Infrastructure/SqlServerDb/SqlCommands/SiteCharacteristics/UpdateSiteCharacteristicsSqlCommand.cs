namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public  class UpdateSiteCharacteristicsSqlCommand
{
    private string _sqlCommand =
        @"
          UPDATE [Farm].[FarmTermAppSiteCharacteristics]

          SET  
                        [Area]                     = @p_Area, 
                       [LandUse]                  = @p_LandUse,         
                        [CropLand]                 = @p_Cropland,                      
                        [WoodLand]                 = @p_Woodland,
                        [Pasture]                  = @p_Pasture,                   
                        [Orchard]                  = @p_Orchard,  
                       [Other]                    = @p_Other,
                        [EasementRightOfway]       = @p_EasementRightOfway,                            
                        [NoteEasementRightOfway]   = @p_NoteEasementRightOfway,                    
                        [MortgageLiens]           = @p_MortgageLiens,                 
                        [NoteMortgageLiens]       = @p_NoteMortgageLiens,  
                       [LastUpdatedBy]            = @p_LastUpdatedBy,
                       [LastUpdatedOn]            = @p_LastUpdatedOn
                      
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId ";

    public UpdateSiteCharacteristicsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }


}
