

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
                 [EasementRightOfway],
                 [NoteEasementRightOfway],
                 [MortgageLiens],
                 [NoteMortgageLiens],
                 [LastUpdatedBy],
                 [LastUpdatedOn]
           FROM [Farm].[FarmTermAppSiteCharacteristics]
            WHERE ApplicationId = @p_ApplicationId;";


    public GetSiteCharacteristicsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }



}


