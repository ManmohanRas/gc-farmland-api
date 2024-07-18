namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateFarmBlockLotSqlCommand
{
    private readonly string _sqlCommand =
          @"UPDATE [Farm].[FarmMunicipalityBlockLotParcel]
                       SET [MunicipalityId] = @p_MunicipalityId
                          ,[FarmListID] = @p_FarmListID
                          ,[Block] = @p_Block
                          ,[Lot] = @p_Lot
                          ,[QualificationCode] = @p_QualificationCode
                          ,[Partial]           = @p_Partial
                          ,[Section] = @p_Section
                          ,[Acres] = @p_Acres
                          ,[AcresToBeAcquired] = @p_AcresToBeAcquired
                          ,[ExceptionArea] = @p_ExceptionArea
                          ,[Notes] = @p_Notes
                          ,[PamsPin] = @p_PamsPin
                          ,[IsValidFeatureId] = @p_IsValidFeatureId
                          ,[InterestType] = @p_InterestType
                          ,[EasementId] = @p_EasementId
                          ,[ChangeType] = @p_ChangeType
                          ,[ChangeDate] = @p_ChangeDate
                          ,[ReasonForChange] = @p_ReasonForChange
                          ,[IsActive] = @p_IsActive
                          ,[LastUpdatedOn] = @p_LastUpdatedBy
                          ,[LastUpdatedBy] = @p_LastUpdatedOn
                     WHERE Id = @p_Id and FarmListID = @p_FarmListID;";

    public UpdateFarmBlockLotSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
