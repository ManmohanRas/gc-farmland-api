

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetSiteCharacteristicsSqlCommand
{
    private readonly string _sqlCommand =
        @" SELECT [Id] ,
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
FROM [Farm].[FarmTermAppSiteCharacteristics];

         ";


    public GetSiteCharacteristicsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }



}


