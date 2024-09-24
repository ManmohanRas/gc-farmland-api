namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmAgriEnterpriseChecklistSqlCommad
{
    private readonly string _sqlCommand =
            @" INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
               (
                [ApplicationId]
               ,[ActivitySubTypeId]
               ,[Title]
               ,[SicCode]
               ,[IsPrimary]
               ,[IsSecondary]
               ,LastUpdatedBy
			   ,LastUpdatedOn
               )
            VALUES
               (
                @p_ApplicationId
               ,@p_ActivitySubTypeId
               ,@p_Title
               ,@p_SicCode
               ,@p_IsPrimary
               ,@p_IsSecondary
               ,@p_LastUpdatedBy  
			   ,@p_LastUpdatedOn
               );
             SELECT CAST(SCOPE_IDENTITY() AS INT);";

    public CreateFarmAgriEnterpriseChecklistSqlCommad() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
