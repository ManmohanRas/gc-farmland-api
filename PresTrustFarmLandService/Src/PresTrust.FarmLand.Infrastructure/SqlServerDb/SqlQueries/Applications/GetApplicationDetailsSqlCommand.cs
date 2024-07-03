namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn],
				A.[IsApprovedByMunicipality],
				[AgencyJSON]
               FROM [Farm].[FarmApplication] AS A
			JOIN
				(
					SELECT		[AgencyId],
								[AgencyName],
								(SELECT			[AgencyId] AS [Id],
												[AgencyName],
												[AgencyLabel],
												CASE [AgencyType] 
					     								WHEN 'Non-Profit' THEN 'nonprofit'
					     								WHEN 'Municipal' THEN 'municipality'
												END AS [AgencyType],
												[EntityType],
												[EntityName],
												[AddressLine1],
												[AddressLine2],
												[AddressLine3],
												[City],
												[State],
												[ZipCode]
									FOR JSON PATH,
									WITHOUT_ARRAY_WRAPPER) AS [AgencyJSON]
					FROM		[Core].[View_AgencyEntities_FARM]
			) FARM_AGENCY ON A.[AgencyId] = FARM_AGENCY.[AgencyId]
               WHERE A.Id = @p_Id;";

    public override string ToString()
    {
        return _sqlCommand;
    }
}
