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
														   ,MBL.Acres
														   ,MBL.AcresToBeAcquired
														   ,MBL.Partial
														   ,MBL.ExceptionArea
														   ,MBL.EasementId
														   ,MBL.ChangeType
														   ,MBL.ChangeDate
														   ,MBL.ReasonForChange
              FROM [Farm].[FarmMunicipalityBlockLotParcel] MBL;";

    public override string ToString()
    {
        return _sqlCommand;
    }

}

