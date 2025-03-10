namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmListSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT
               FL.[FarmListID]
              ,ISNULL(FL.[FarmNumber], '') AS FarmNumber
              ,FL.[FarmName]
              ,FL.[Status]
              ,FL.[AgencyID]
              ,FL.[OriginalLandowner]
              ,FL.[Address1]
              ,FL.[Address2]
              ,FL.[MunicipalID]
              ,AgencyEntity.[AgencyLabel] AS PresentOwner
              FROM [Farm].[FarmList] FL
              LEFT JOIN [Core].[View_AgencyEntities_FARM] AgencyEntity ON (FL.AgencyId = AgencyEntity.AgencyId)
               WHERE FarmName IS NOT NULL;";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }
}
