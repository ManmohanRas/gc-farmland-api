namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetUnLinkedParcelsByFarmId
{
    private readonly string _sqlCommand =
        @"  SELECT DISTINCT
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
    MBL.Acres,
    MBL.AcresToBeAcquired,
    MBL.ExceptionAreaAcres,
    MBL.Partial,
    MBL.ExceptionArea,
    MBL.EasementId,
    MBL.ChangeType,
    MBL.ChangeDate,
    MBL.ReasonForChange,
    CP.PropertyClassCode AS PropertyClassCode,
    MBL.DeedBook,
    MBL.DeedPage,
    MBL.IsWarning,
    MBL.[Notes],
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
LEFT JOIN [Farm].[FarmTermAppLocation] AS L 
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
  -- Main query condition: exclude records with ApplicationTypeId = 1
  AND (
      (L.ApplicationId = @p_ApplicationId)  -- Keep the exact application match
      OR NOT EXISTS (
          -- The subquery checks if there is another ParcelId with a different ApplicationId
          SELECT 1
          FROM [Farm].[FarmTermAppLocation] AS L2
          LEFT JOIN [Farm].[FarmApplication] FA2 
              ON FA2.Id = L2.ApplicationId
          WHERE L2.ParcelId = MBL.Id
            AND L2.ApplicationId <> @p_ApplicationId  -- It must be a different application
            AND FA2.ApplicationTypeId = @p_ApplicationTypeId
      )
  );";
    public GetUnLinkedParcelsByFarmId()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
