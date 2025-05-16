namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmBlockLotSqlCommand
{
    private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmMunicipalityBlockLotParcel]
                       ([MunicipalityId]
                       ,[FarmListID]
                       ,[Block]
                       ,[Lot]
                       ,[QualificationCode]
                       ,[Partial]
                       ,[Section]
                       ,[PamsPin]
                       ,[IsValidFeatureId]
                       ,[InterestType]
                       ,[EasementId]
                       ,[ChangeType]
                       ,[ChangeDate]
                       ,[ReasonForChange]
                       ,[IsActive]
                       ,[PropertyClassCode]
                       ,[DeedBook]
                       ,[DeedPage]
                       ,[CreatedByProgramUser]
                       ,[IsWarning]
                       ,[IsValidPamsPin]
                       ,[LastUpdatedOn]
                       ,[LastUpdatedBy])
                 VALUES
                       (@p_MunicipalityId
                       ,@p_FarmListID
                       ,@p_Block
                       ,@p_Lot
                       ,@p_QualificationCode
                       ,@p_Partial
                       ,@p_Section
                       ,@p_PamsPin
                       ,@p_IsValidFeatureId
                       ,@p_InterestType
                       ,@p_EasementId
                       ,@p_ChangeType
                       ,@p_ChangeDate
                       ,@p_ReasonForChange
                       ,@p_IsActive
                       ,@p_PropertyClassCode
                       ,@p_DeedBook
                       ,@p_DeedPage
                       ,@p_CreatedByProgramUser
                       ,@p_IsWarning
                       ,@p_IsValidPamsPin
                       ,GETDATE()
                       ,@p_LastUpdatedBy);

                SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmBlockLotSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
