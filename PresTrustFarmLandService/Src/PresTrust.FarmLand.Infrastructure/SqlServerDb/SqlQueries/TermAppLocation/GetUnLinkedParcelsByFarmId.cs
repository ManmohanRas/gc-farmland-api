namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetUnLinkedParcelsByFarmId
{
    private readonly string _sqlCommand =
        @" WITH ExcludedParcels AS (
    SELECT L.ParcelId
    FROM [Farm].[FarmAppLocationDetails] L
    JOIN [Farm].[FarmApplication] A ON L.ApplicationId = A.Id
    WHERE L.IsChecked = 1
      AND A.ApplicationTypeId = @p_ApplicationTypeId  -- Apply filter to match ApplicationTypeId
      AND L.ApplicationId <> @p_ApplicationId        -- Exclude current application
)

SELECT DISTINCT
    MBL.Id AS ParcelId,
    MBL.[Id],
    MBL.[FarmListID],
    MBL.[MunicipalityID],
    MBL.[Block],
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
    CP.PropertyClassCode AS PropertyClassCode,
    MBL.DeedBook,
    MBL.DeedPage,
    MBL.IsWarning,
    L.[Notes],
    MBL.[CreatedByProgramUser],
    MBL.[IsValidPamsPin],
    L.IsChecked,
    L.ApplicationId,
    CM.[Municipality] AS Municipality,
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
LEFT JOIN [Core].[View_AgencyEntities_FARM] ViewAgency 
    ON MBL.MunicipalityId = ViewAgency.AgencyId
LEFT JOIN [Core].[Municipality] CM 
    ON MBL.MunicipalityId = CM.MunicipalId 
    AND CM.InCounty = 1
LEFT JOIN CORE.Parcels CP 
    ON CP.PAMS_PIN = MBL.PamsPin
WHERE MBL.FarmListID = @p_FarmListID
  AND NOT EXISTS (
        SELECT 1
        FROM ExcludedParcels EP
        WHERE EP.ParcelId = MBL.Id
  );";
    public GetUnLinkedParcelsByFarmId()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
