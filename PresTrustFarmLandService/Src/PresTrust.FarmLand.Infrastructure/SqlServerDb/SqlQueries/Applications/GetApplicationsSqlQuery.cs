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
                A.[IsSADC],
				FL.[FarmName],
				FL.[MunicipalID],
				FL.[Municipality],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[OwnerPropertyLEGACY_Rev01] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
               WHERE A.IsActive = 1;";


    public GetApplicationsSqlQuery(bool isExternalUser = false)
    {
        if (isExternalUser)
        {
            _sqlCommand =
       @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
				FL.[MunicipalID],
				FL.[Municipality],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[OwnerPropertyLEGACY_Rev01] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
               WHERE A.IsActive = 1 AND A.AgencyId IN @p_agencyIds;";
        }else
        {
            _sqlCommand =
               @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
				FL.[MunicipalID],
				FL.[Municipality],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[OwnerPropertyLEGACY_Rev01] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
               WHERE A.IsActive = 1;";
        }
    }

    public override string ToString()
    {
        return _sqlCommand;
    }


}
