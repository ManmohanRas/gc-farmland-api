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
				Max(ASL.[StatusId] )AS PrevStatusId,
                A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[FarmList] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
                LEFT JOIN
			   (
			    SELECT L.ApplicationId, SUM(MBL.AcresToBeAcquired) AS Acres
				FROM [Farm].[FarmMunicipalityBlockLotParcel]  AS MBL
			  LEFT JOIN [Farm].[FarmAppLocationDetails] AS L ON (MBL.Id = L.ParcelId AND L.Ischecked = 1)
			  GROUP BY L.ApplicationId
			   ) AS LP ON (A.Id = LP.ApplicationId)
			   LEFT JOIN	[Farm].[FarmApplicationStatusLog] ASL ON ASL.StatusId != A.StatusId AND A.Id = ASL.ApplicationId
			   LEFT JOIN [Farm].[FarmEsmtAppAdminClosingDocStatus] FCDS On A.Id = FCDS.ApplicationId	
               WHERE AP.IsActive = 1
			   Group by
			   A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
				A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] ,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
               ORDER BY AP.[CreatedOn] DESC;";


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
                Max(ASL.[StatusId] )AS PrevStatusId,
                A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[FarmList] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
                LEFT JOIN
			   (
			    SELECT L.ApplicationId, SUM(MBL.AcresToBeAcquired) AS Acres
				FROM [Farm].[FarmMunicipalityBlockLotParcel]  AS MBL
			  LEFT JOIN [Farm].[FarmAppLocationDetails] AS L ON (MBL.Id = L.ParcelId AND L.Ischecked = 1)
			  GROUP BY L.ApplicationId
			   ) AS LP ON (A.Id = LP.ApplicationId)
                LEFT JOIN	[Farm].[FarmApplicationStatusLog] ASL ON ASL.StatusId != A.StatusId AND A.Id = ASL.ApplicationId
			   LEFT JOIN [Farm].[FarmEsmtAppAdminClosingDocStatus] FCDS On A.Id = FCDS.ApplicationId	
                  WHERE A.IsActive = 1 AND A.AgencyId IN @p_agencyIds
                 Group by
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
                AgencyEntity.[AgencyLabel] ,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
             
               ORDER BY A.[CreatedOn] DESC;";
        }else
        {
            _sqlCommand =
               @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
               Max(ASL.[StatusId] )AS PrevStatusId,
                A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] AS PresentOwner,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
               FROM [Farm].[FarmApplication] AS A
               LEFT JOIN [Farm].[FarmList] AS FL ON (A.AgencyId = FL.AgencyId AND A.FarmListId = FL.FarmListID)
               LEFT JOIN [Core].[View_AgencyEntities_FARM] AS AgencyEntity ON (AgencyEntity.AgencyId = A.AgencyId)
               LEFT JOIN [Farm].[FarmTermAppAdminDetails] AS AD ON (A.Id = AD.ApplicationId)
               LEFT JOIN
			   (
			    SELECT L.ApplicationId, SUM(MBL.AcresToBeAcquired) AS Acres
				FROM [Farm].[FarmMunicipalityBlockLotParcel]  AS MBL
			  LEFT JOIN [Farm].[FarmAppLocationDetails] AS L ON (MBL.Id = L.ParcelId AND L.Ischecked = 1)
			  GROUP BY L.ApplicationId
			   ) AS LP ON (A.Id = LP.ApplicationId)
                 LEFT JOIN	[Farm].[FarmApplicationStatusLog] ASL ON ASL.StatusId != A.StatusId AND A.Id = ASL.ApplicationId
			   LEFT JOIN [Farm].[FarmEsmtAppAdminClosingDocStatus] FCDS On A.Id = FCDS.ApplicationId	

                WHERE A.IsActive = 1
                 Group by
			   A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
				A.[CreatedOn],
                A.[FarmListId],
                A.[IsSADC],
				FL.[FarmName],
                FL.[OriginalLandowner],
                AgencyEntity.[AgencyLabel] ,
                AD.[EnrollmentDate],
                LP.Acres,
                FCDS.[ClosingDate]
               ORDER BY A.[CreatedOn] DESC;";
        }
    }

    public override string ToString()
    {
        return _sqlCommand;
    }


}
