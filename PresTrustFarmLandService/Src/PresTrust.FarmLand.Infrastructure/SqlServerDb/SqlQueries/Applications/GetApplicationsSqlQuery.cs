namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationsSqlQuery
{
    private readonly string _sqlCommand =
        @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn],
                A.[FarmListId],
				FL.[FarmName],
				FL.[MunicipalID],
				FL.[Municipality],
                FL.[OriginalLandowner]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[OwnerPropertyLEGACY_Rev01] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               WHERE A.IsActive = 1;";

    public override string ToString()
    {
        return _sqlCommand;
    }

}
