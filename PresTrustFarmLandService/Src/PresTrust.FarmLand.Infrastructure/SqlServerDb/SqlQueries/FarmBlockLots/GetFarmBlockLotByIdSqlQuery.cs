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
		      ,MBL.Partial
			  ,MBL.ExceptionArea
			  ,MBL.EasementId
			  ,MBL.ChangeType
			  ,MBL.ChangeDate
			  ,MBL.ReasonForChange
			  ,MBL.PropertyClassCode
			  ,MBL.DeedBook
			  ,MBL.DeedPage
			  ,MBL.IsWarning
			  ,MBL.[Notes]
			  ,MBL.[CreatedByProgramUser]
              FROM [Farm].[FarmMunicipalityBlockLotParcel] MBL
			  WHERE  MBL.Id = @p_Id;";

    public GetFarmBlockLotByIdSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
