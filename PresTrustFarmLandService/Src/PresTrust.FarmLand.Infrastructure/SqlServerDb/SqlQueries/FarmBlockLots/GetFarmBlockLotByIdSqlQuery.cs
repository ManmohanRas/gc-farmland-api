namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmBlockLotByIdSqlQuery
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
			  ,MBL.DeedBook
			  ,MBL.DeedPage
			  ,MBL.IsWarning
			  ,MBL.[Notes]
			  ,MBL.[CreatedByProgramUser]
			  ,MBL.[IsValidPamsPin]
			  ,CP.PropertyClassCode AS PropertyClassCode
              FROM [Farm].[FarmMunicipalityBlockLotParcel] MBL
			  LEFT JOIN CORE.Parcels CP ON (CP.PAMS_PIN = MBL.PamsPin)
			  WHERE  MBL.Id = @p_Id;";

    public GetFarmBlockLotByIdSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
