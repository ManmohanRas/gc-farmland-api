namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmAgriEnterpriseChecklistSqlCommad
{
    private readonly string _sqlCommand =
            @" UPDATE [Farm].[FarmAgriculturalEnterpriseChecklist]
               SET
                       [ActivitySubTypeId]  = @p_ActivitySubTypeId
                       ,[Title]             = @p_Title
                       ,[SicCode]           = @p_SicCode
                       ,[IsPrimary]          = @p_IsPrimary
                       ,[IsSecondary]        = @p_IsSecondary
                       ,[LastUpdatedBy]      = @p_LastUpdatedBy
                       ,[LastUpdatedOn]      = @p_LastUpdatedOn
               WHERE    Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateFarmAgriEnterpriseChecklistSqlCommad() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
