

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetSiteCharacteristicsSqlCommand
{
    private readonly string _sqlCommand =
        @" SELECT [Id] ,
                 ST.[ApplicationId],
                 A.Acres AS [Area],
                 ST.[LandUse],
                 ST.[Cropland],
                 ST.[Woodland],
                 ST.[Pasture],
                 ST.[Orchard],
                 ST.[Other],
                 ST.[IsEasement],
                 ST.[IsRightOfway],
                 ST.[NoteEasementRightOfway],
                 ST.[IsMortgage],
                 ST.[IsLiens],
                 ST.[NoteMortgageLiens],
                 ST.[LastUpdatedBy],
                 ST.[LastUpdatedOn]
           FROM [Farm].[FarmTermAppSiteCharacteristics] ST
             RIGHT JOIN 
				(
				  SELECT L.ApplicationId, SUM(MBL.AcresToBeAcquired) AS Acres
					FROM [Farm].[FarmMunicipalityBlockLotParcel]  AS MBL
					LEFT JOIN [Farm].[FarmAppLocationDetails] AS L ON (MBL.Id = L.ParcelId AND L.Ischecked = 1)
					GROUP BY L.ApplicationId
				) A ON ST.ApplicationId = A.ApplicationId
            WHERE ST.ApplicationId = @p_ApplicationId;";


    public GetSiteCharacteristicsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }



}


