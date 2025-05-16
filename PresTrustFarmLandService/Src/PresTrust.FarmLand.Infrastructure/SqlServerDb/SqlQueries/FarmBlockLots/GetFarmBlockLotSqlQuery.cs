namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public  class GetFarmBlockLotSqlQuery
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
		      ,MBL.Partial
			  ,MBL.EasementId
			  ,MBL.ChangeType
			  ,MBL.ChangeDate
			  ,MBL.ReasonForChange
			  ,CP.PropertyClassCode AS PropertyClassCode
			  ,MBL.DeedBook
			  ,MBL.DeedPage
			  ,MBL.IsWarning
			  ,MBL.[CreatedByProgramUser]
		      ,MBL.[IsValidPamsPin]
			  ,CP.PropertyClassCode AS CorePropertyClassCode
			  ,CASE 
				WHEN CP.PropertyClassCode IS NOT NULL AND CP.PropertyClassCode <> '3B' 
				THEN 1
				ELSE 0
				END AS IsClassCodeWarning
              FROM [Farm].[FarmMunicipalityBlockLotParcel] MBL
			  LEFT JOIN CORE.Parcels CP ON (CP.PAMS_PIN = MBL.PamsPin);";

    public override string ToString()
    {
        return _sqlCommand;
    }

}

