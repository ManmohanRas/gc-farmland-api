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
				MAX(ASL.StatusId) AS PrevStatusId,
                A.[CreatedOn],
				A.[IsApprovedByMunicipality],
				A.[FarmListID],
				A.[IsSADC],
				[AgencyJSON],
				FL.[FarmName]
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
												[ZipCode],
												[PrimaryTelephone],
												[AgencyEmail]
									FOR JSON PATH,
									WITHOUT_ARRAY_WRAPPER) AS [AgencyJSON]
					FROM		[Core].[View_AgencyEntities_FARM]
			) FARM_AGENCY ON A.[AgencyId] = FARM_AGENCY.[AgencyId]
			LEFT JOIN [Farm].[FarmList] AS FL ON (A.[AgencyId] = FL.[AgencyId] AND A.[FarmListID] = FL.[FarmListID])
			LEFT JOIN	[Farm].[FarmApplicationStatusLog] ASL ON ASL.StatusId != A.StatusId AND A.Id = ASL.ApplicationId
               WHERE A.Id = @p_Id
				GROUP BY
				A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
				 A.[CreatedOn],
				A.[IsApprovedByMunicipality],
				A.[FarmListID],
				A.[IsSADC],
				[AgencyJSON],
				FL.[FarmName];";

    public override string ToString()
    {
        return _sqlCommand;
    }
}
