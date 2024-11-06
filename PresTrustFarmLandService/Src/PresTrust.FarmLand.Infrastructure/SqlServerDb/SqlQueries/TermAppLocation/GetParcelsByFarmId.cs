namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetParcelsByFarmId
{
    private readonly string _sqlCommand =
        @"  SELECT Distinct
               MBL.Id AS ParcelId,
               MBL.[Id],
               MBL.[FarmListID]
              ,MBL.[MunicipalityID]
              ,MBL.[Block]
			  ,MBL.Lot
			  ,MBL.QualificationCode
			  ,MBL.IsActive
			  ,MBL.InterestType
			  ,MBL.Section
			  ,MBL.PamsPin
			  ,MBL.Acres
			  ,MBL.AcresToBeAcquired
              ,MBL.ExceptionAreaAcres
		      ,MBL.Partial
			  ,MBL.ExceptionArea
			  ,MBL.EasementId
			  ,MBL.ChangeType
			  ,MBL.ChangeDate
			  ,MBL.ReasonForChange
			  ,CP.PropertyClassCode AS PropertyClassCode
			  ,MBL.DeedBook
			  ,MBL.DeedPage
			  ,MBL.IsWarning
			  ,MBL.[Notes]
			  ,MBL.[CreatedByProgramUser]
              ,MBL.[IsValidPamsPin],
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
           LEFT JOIN [Farm].[FarmTermAppLocation] AS L ON (MBL.FarmListID = L.FarmListID and MBL.Id = L.ParcelId AND L.applicationId = @p_ApplicationId)
           LEFT JOIN [Core].[View_AgencyEntities_FARM] ViewAgency ON (MBL.MunicipalityId = ViewAgency.AgencyId)
           LEFT JOIN [Core].[Municipality] CM ON (MBL.MunicipalityId = CM.MunicipalId AND CM.InCounty = 1)
           LEFT JOIN CORE.Parcels CP ON (CP.PAMS_PIN = MBL.PamsPin)
           WHERE MBL.FarmListID = @p_FarmListID;";
    public GetParcelsByFarmId()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
