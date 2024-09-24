namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAgriEnterpriseChecklistSqlQuery
{
    private readonly string _sqlCommand =
       @"  SELECT  distinct  FE.Id
                    ,FE.ApplicationId
                    ,FS.Id AS ActivitySubTypeId
                    ,FS.Title
                    ,FS.SicCode
                    ,FS.ActivityTypeId
                    ,FE.IsPrimary
                    ,FE.IsSecondary
            FROM [Farm].[FarmEsmtAgricultureProdSourceType] FS 
            LEFT JOIN [Farm].[FarmAgriculturalEnterpriseChecklist] FE ON (FE.ApplicationId = @p_ApplicationId 
            AND FS.Id = FE.ActivitySubTypeId);";
           


    public GetFarmEsmtAgriEnterpriseChecklistSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}