namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetUnLinkedParcelsByFarmId
{
    private readonly string _sqlCommand =
        @" WITH ParcelsCheckedInProtectedApps AS (
    SELECT DISTINCT L.ParcelId
    FROM [Farm].[FarmAppLocationDetails] L
    JOIN [Farm].[FarmApplication] A ON L.ApplicationId = A.Id
    WHERE L.IsChecked = 1
      AND L.ApplicationId <> @p_ApplicationId
      AND A.ApplicationTypeId = @p_ApplicationTypeId
     
      AND A.StatusId IN (101,102, 103, 104, 105,201,202, 203, 204, 205, 206, 209, 210)
            )

            SELECT DISTINCT
                MBL.Id AS ParcelId,
                MBL.Id,
                MBL.FarmListID,
                MBL.MunicipalityID,
                MBL.Block,
                MBL.Lot,
                MBL.QualificationCode,
                MBL.IsActive,
                MBL.InterestType,
                MBL.Section,
                MBL.PamsPin,
                L.Acres,
                L.AcresToBeAcquired,
                L.ExceptionAreaAcres,
                MBL.Partial,
                L.ExceptionArea,
                MBL.EasementId,
                MBL.ChangeType,
                MBL.ChangeDate,
                MBL.ReasonForChange,
                CP.PropertyClassCode,
                MBL.DeedBook,
                MBL.DeedPage,
                MBL.IsWarning,
                L.Notes,
                MBL.CreatedByProgramUser,
                MBL.IsValidPamsPin,

                ISNULL(L.IsChecked, 0) AS IsChecked,

                L.ApplicationId,
                CM.Municipality,
                CP.PropertyClassCode AS CorePropertyClassCode,
                CASE 
                    WHEN CP.PropertyClassCode IS NOT NULL AND CP.PropertyClassCode <> '3B'
                    THEN 1
                    ELSE 0
                END AS IsClassCodeWarning

            FROM [Farm].[FarmMunicipalityBlockLotParcel] AS MBL

            LEFT JOIN [Farm].[FarmAppLocationDetails] AS L 
                ON MBL.FarmListID = L.FarmListID 
                AND MBL.Id = L.ParcelId 
                AND L.ApplicationId = @p_ApplicationId

            -- Join parcels that are blocked by other apps
            LEFT JOIN ParcelsCheckedInProtectedApps OC
                ON MBL.Id = OC.ParcelId


            LEFT JOIN [Core].[Municipality] CM 
                ON MBL.MunicipalityId = CM.MunicipalId 
                AND CM.InCounty = 1

            LEFT JOIN [Core].[Parcels] CP 
                ON CP.PAMS_PIN = MBL.PamsPin

            WHERE MBL.FarmListID = @p_FarmListID
              AND OC.ParcelId IS NULL;";

    public GetUnLinkedParcelsByFarmId()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
