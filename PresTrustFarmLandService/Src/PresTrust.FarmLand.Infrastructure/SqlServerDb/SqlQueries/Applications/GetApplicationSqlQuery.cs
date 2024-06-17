namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetApplicationSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn],
				FL.[FarmName],
				FL.MunicipalID,
				FL.Municipality
               FROM [Farm].[FarmApplication] AS A
               JOIN [Farm].[OwnerPropertyLEGACY_Rev01] AS FL ON (A.AgencyId = FL.AgencyId)
               WHERE A.IsActive = 1;";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }

}
