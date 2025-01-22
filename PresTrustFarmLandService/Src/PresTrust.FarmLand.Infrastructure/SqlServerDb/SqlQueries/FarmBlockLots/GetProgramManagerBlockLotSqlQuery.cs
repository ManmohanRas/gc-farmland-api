namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public  class GetProgramManagerBlockLotSqlQuery
{
        private readonly string _sqlCommand =
            @" SELECT
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
		      ,MBL.[IsValidPamsPin]
			  ,CP.PropertyClassCode AS CorePropertyClassCode
			  ,CASE 
				WHEN CP.PropertyClassCode IS NOT NULL AND CP.PropertyClassCode <> '3B' 
				THEN 1
				ELSE 0
				END AS IsClassCodeWarning,
				FL.AgencyId,
				FAE.[AgencyLabel] AS LandOwner,
				FAE.AgencyName,
				FAE.AddressLine1 AS PropertyAddress
              FROM [Farm].[FarmMunicipalityBlockLotParcel] MBL
			  LEFT JOIN CORE.Parcels CP ON (CP.PAMS_PIN = MBL.PamsPin)
			  LEFT JOIN [Farm].[FarmList] FL ON (MBL.FarmListId = FL.FarmListId)
			  LEFT JOIN [Core].View_AgencyEntities_FARM FAE ON (FAE.AgencyId = FL.AgencyId)
;";

    public override string ToString()
    {
        return _sqlCommand;
    }

}

