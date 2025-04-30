namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmMonitoringSqlQuery
{

        private readonly string _sqlCommand =
            @" WITH CTE_FarmData AS (
                        SELECT 
                            Farm.FarmApplication.Id AS AppId,
		                    Farm.FarmApplication.FarmListID AS FarmListID,
                            Core.View_AgencyEntities_FARM.AgencyLabel AS PresentOwner,
                            Farm.FarmList.FarmNumber AS FarmNumber,
                            Farm.FarmList.OriginalLandowner AS OriginalLandowner,
                            Farm.FarmList.FarmName AS FarmName,
                            AppOwnerDetails.FirstName AS FirstName,
                            AppOwnerDetails.LastName AS LastName,
                            AppOwnerDetails.MailingAddress1 AS Street1,
                            AppOwnerDetails.MailingAddress2 AS Street2,
                            AppOwnerDetails.City AS City,
                            AppOwnerDetails.State AS State,
                            AppOwnerDetails.ZipCode AS ZipCode,
                            AppOwnerDetails.PhoneNumber AS PhoneNumber,
                            Farm.FarmEsmtAppAdminDetails.FarmerName AS FarmerName,
                            Farm.FarmEsmtAppAdminDetails.IsConservationPlan AS IsConservationPlan,
                            Farm.FarmEsmtAppAdminDetails.ConsPlanDate AS ConsPlanDate,
                            Farm.FarmEsmtAppAdminDetails.ConsPlanComment AS ConsPlanComment,
                            Farm.FarmApplicationStatus.Id AS ApplicationStatusId,
                            Core.Municipality.MunicipalId AS MunicipalId,
                            A.Block AS Block,
                            A.Lot AS Lot,
                            A.PamsPin AS PamsPin,
                            Core.Municipality.Municipality AS Municipality,
                            A.additional_blocks AS AddBlock,
                            A.additional_lots AS AddLots,
                            Farm.FarmEsmtAppAdminClosingDocStatus.ClosingDate AS ClosingDate,
                            Farm.FarmEsmtAppAdminClosingDocStatus.TitlePolicy AS TitlePolicy,
                            Farm.FarmEsmtAppAdminClosingDocStatus.TitleCompany AS TitleCompany,
                            Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedBook AS EPDeedBook,
                            Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedPage AS EPDeedPage,
                            Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedFiled AS EPDeedFiled,
                            Farm.FarmEsmtAppAdminExceptionRDSO.RDSOsNum AS RDSOsNum,
                            Farm.FarmEsmtAppAdminExceptionRDSO.IsRDSOExercised AS IsRDSOExercised,
                            Farm.FarmEsmtAppAdminExceptionRDSO.RDSOExplan AS RDSOExplan,
                            Farm.FarmEsmtAppAdminStructNonAgriWetlands.ImprovRes AS ImprovRes,
                            Farm.FarmEsmtAppAdminStructNonAgriWetlands.AreNonAgUses AS AreNonAgUses,
                            Farm.FarmEsmtAppAdminStructNonAgriWetlands.ImprovAg AS ImprovAg,
                            Farm.FarmEsmtAppAdminStructNonAgriWetlands.NonAgExplan AS NonAgExplan,
                            Farm.FarmEsmtAppAdminCostDetails.GrossAcers AS GrossAcers,
                            A1.Acres AS NetAcres
                        FROM 
                            Farm.FarmApplication
                        LEFT JOIN 
                            Core.View_AgencyEntities_FARM 
                            ON Core.View_AgencyEntities_FARM.AgencyId = Farm.FarmApplication.AgencyId
                        LEFT JOIN 
                            Farm.FarmList 
                            ON Farm.FarmList.FarmListID = Farm.FarmApplication.FarmListId
                        LEFT JOIN 
                            Farm.FarmAppOwnerDetailList 
                            ON Farm.FarmAppOwnerDetailList.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            Farm.FarmEsmtAppAdminDetails 
                            ON Farm.FarmEsmtAppAdminDetails.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            Farm.FarmApplicationStatus 
                            ON Farm.FarmApplicationStatus.Id = Farm.FarmApplication.StatusId
                        LEFT JOIN 
                            Core.Municipality 
                            ON Core.Municipality.MunicipalId = Farm.FarmList.MunicipalID
                        LEFT JOIN 
                            Farm.FarmEsmtAppAdminClosingDocStatus 
                            ON Farm.FarmEsmtAppAdminClosingDocStatus.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            Farm.FarmEsmtAppAdminCostDetails 
                            ON Farm.FarmEsmtAppAdminCostDetails.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            Farm.FarmEsmtAppAdminExceptionRDSO 
                            ON Farm.FarmEsmtAppAdminExceptionRDSO.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            Farm.FarmEsmtAppAdminStructNonAgriWetlands 
                            ON Farm.FarmEsmtAppAdminStructNonAgriWetlands.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            (
                                SELECT
                                    o.ApplicationId,
                                    o.block AS Block,
                                    o.Lot AS Lot,
                                    o.PamsPin,
                                    STRING_AGG(a.block, ', ') AS additional_blocks,
                                    STRING_AGG(a.Lot, ', ') AS additional_lots
                                FROM
                                    (
                                        SELECT
                                            ApplicationId,
                                            Block,
                                            Lot,
                                            PamsPin
                                        FROM 
                                            (
                                                SELECT
                                                    L.ApplicationId,
                                                    BPL.Block,
                                                    BPL.Lot,
                                                    BPL.PamsPin,
                                                    ROW_NUMBER() OVER (PARTITION BY L.ApplicationId ORDER BY Id) AS rn
                                                FROM 
                                                    [Farm].[FarmAppLocationDetails] L
                                                LEFT JOIN 
                                                    Farm.FarmMunicipalityBlockLotParcel BPL 
                                                    ON BPL.Id = L.ParcelId
                                                WHERE L.IsChecked = 1
                                            ) AS subquery
                                        WHERE rn = 1
                                    ) AS o
                                LEFT JOIN 
                                    (
                                        SELECT
                                            ApplicationId,
                                            block,
                                            lot,
                                            PamsPin
                                        FROM 
                                            (
                                                SELECT
                                                    L.ApplicationId,
                                                    BPL.block,
                                                    BPL.lot,
                                                    BPL.PamsPin,
                                                    ROW_NUMBER() OVER (PARTITION BY L.ApplicationId ORDER BY Id) AS rn
                                                FROM 
                                                    [Farm].[FarmAppLocationDetails] L
                                                LEFT JOIN 
                                                    Farm.FarmMunicipalityBlockLotParcel BPL 
                                                    ON BPL.Id = L.ParcelId
                                                WHERE L.IsChecked = 1
                                            ) AS subquery
                                        WHERE rn > 1
                                    ) AS a
                                ON o.ApplicationId = a.ApplicationId
                                AND a.block <> o.block
                                AND a.lot <> o.lot
                                AND a.PamsPin <> o.PamsPin
                                GROUP BY 
                                    o.ApplicationId, o.lot, o.block, o.PamsPin
                            ) A 
                            ON A.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            (
                                SELECT 
                                    L.ApplicationId, 
                                    SUM(L.AcresToBeAcquired) AS Acres
                                FROM 
                                    Farm.FarmMunicipalityBlockLotParcel AS MBL
                                LEFT JOIN 
                                    [Farm].[FarmAppLocationDetails] AS L 
                                    ON (MBL.Id = L.ParcelId AND L.IsChecked = 1)
                                GROUP BY 
                                    L.ApplicationId
                            ) A1 
                            ON A1.ApplicationId = Farm.FarmApplication.Id
                        LEFT JOIN 
                            (
                                SELECT
                                    ApplicationId,
                                    FirstName,
                                    LastName,
                                    state,
                                    MailingAddress1,
                                    MailingAddress2,
                                    City,
                                    ZipCode,
                                    PhoneNumber
                                FROM 
                                    (
                                        SELECT 
                                            ApplicationId,
                                            FirstName,
                                            LastName,
                                            state,
                                            MailingAddress1,
                                            MailingAddress2,
                                            City,
                                            ZipCode,
                                            PhoneNumber,
                                            ROW_NUMBER() OVER (PARTITION BY ApplicationId ORDER BY Id) AS rn
                                        FROM 
                                            Farm.FarmAppOwnerDetailList
                                    ) AS subquery  
                                WHERE rn = 1
                            ) AS AppOwnerDetails 
                            ON AppOwnerDetails.ApplicationId = Farm.FarmApplication.Id
                        WHERE 
                            Farm.FarmApplicationStatus.Id = 206 and A.PamsPin is not null
		                    GROUP BY
                        Farm.FarmApplication.Id,
	                    Farm.FarmApplication.FarmListID,
                        Core.View_AgencyEntities_FARM.AgencyLabel,
                        Farm.FarmList.FarmNumber,
                        Farm.FarmList.OriginalLandowner,
                        Farm.FarmList.FarmName,
                        AppOwnerDetails.FirstName,
                        AppOwnerDetails.LastName,
                        AppOwnerDetails.MailingAddress1,
                        AppOwnerDetails.MailingAddress2,
                        AppOwnerDetails.City,
                        AppOwnerDetails.State,
                        AppOwnerDetails.ZipCode,
                        AppOwnerDetails.PhoneNumber,
                        Farm.FarmEsmtAppAdminDetails.FarmerName,
                        Farm.FarmEsmtAppAdminDetails.IsConservationPlan,
                        Farm.FarmEsmtAppAdminDetails.ConsPlanDate,
                        Farm.FarmEsmtAppAdminDetails.ConsPlanComment,
                        Farm.FarmApplicationStatus.Id,
                        Core.Municipality.MunicipalId,
                        A.Block,
                        A.Lot,
                        A.PamsPin,
                        Core.Municipality.Municipality,
                        A.additional_blocks,
                        A.additional_lots,
                        Farm.FarmEsmtAppAdminClosingDocStatus.ClosingDate,
                        Farm.FarmEsmtAppAdminClosingDocStatus.TitlePolicy,
                        Farm.FarmEsmtAppAdminClosingDocStatus.TitleCompany,
                        Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedBook,
                        Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedPage,
                        Farm.FarmEsmtAppAdminClosingDocStatus.EPDeedFiled,
                        Farm.FarmEsmtAppAdminExceptionRDSO.RDSOsNum,
                        Farm.FarmEsmtAppAdminExceptionRDSO.IsRDSOExercised,
                        Farm.FarmEsmtAppAdminExceptionRDSO.RDSOExplan,
                        Farm.FarmEsmtAppAdminStructNonAgriWetlands.ImprovRes,
                        Farm.FarmEsmtAppAdminStructNonAgriWetlands.AreNonAgUses,
                        Farm.FarmEsmtAppAdminStructNonAgriWetlands.ImprovAg,
                        Farm.FarmEsmtAppAdminStructNonAgriWetlands.NonAgExplan,
                        Farm.FarmEsmtAppAdminCostDetails.GrossAcers,
                        A1.Acres
                    )

                    --select * from CTE_FarmData



                    SELECT 
                        ISNULL(FM.Id, 0) AS Id,
                        CTE_FarmData.AppId AS AppId,
                        CTE_FarmData.FarmListID,

                        --CTE_FarmData.PresentOwner,
                        --CTE_FarmData.FarmNumber,
                        --CTE_FarmData.OriginalLandowner,
                        --CTE_FarmData.FarmName,
                        --CTE_FarmData.FirstName,
                        --CTE_FarmData.LastName,

                        CONCAT(COALESCE(FM.Street1, CTE_FarmData.Street1), ' ', COALESCE(FM.Street2, CTE_FarmData.Street2))
                        AS FarmLocation,


                        --CTE_FarmData.Street1,
                        --CTE_FarmData.Street2,
                        --CTE_FarmData.City,
                        --CTE_FarmData.State,
                        --CTE_FarmData.ZipCode,
                        --CTE_FarmData.PhoneNumber, 
                        --CTE_FarmData.FarmerName,
                        --CTE_FarmData.IsConservationPlan,
                        --CTE_FarmData.ConsPlanDate,
                        --CTE_FarmData.ConsPlanComment,

                        CTE_FarmData.ApplicationStatusId,
                        CTE_FarmData.MunicipalId,
                        CTE_FarmData.Block,
                        CTE_FarmData.Lot,
                        CTE_FarmData.PamsPin,
                        CTE_FarmData.Municipality,   
                        CTE_FarmData.AddBlock,
                        CTE_FarmData.AddLots,

                        --CTE_FarmData.ClosingDate,
                        --CTE_FarmData.TitlePolicy,
                        --CTE_FarmData.TitleCompany,
                        --CTE_FarmData.EPDeedBook,
                        --CTE_FarmData.EPDeedPage,
                        --CTE_FarmData.EPDeedFiled,
                        --CTE_FarmData.RDSOsNum,
                        --CTE_FarmData.IsRDSOExercised,
                        --CTE_FarmData.RDSOExplan,
                        --CTE_FarmData.ImprovRes,
                        --CTE_FarmData.AreNonAgUses,
                        --CTE_FarmData.ImprovAg,
                        --CTE_FarmData.NonAgExplan,
                        --CTE_FarmData.GrossAcers,

                          CTE_FarmData.NetAcres,

	                    FM.FirstInspect,
	                    FM.PreviousInspect,
	                    FM.LastInspect,
	                    FM.ChangesSinceLastInspect,
	                    FM.IssuesImpactingFarm,
	                    FM.IsInCompliance,
	                    FM.NonComplianceExplan,
	                    FM.InspectionComments,
	                    FM.CurrentDeedBook,
	                    FM.CurrentDeedPage,
	                    FM.CurrentDeedFiled,
    
                        -- Use COALESCE to pull data from CTE_FarmData if any column in FarmMonitoringDetails is NULL
                        --COALESCE(FM.FarmListID, CTE_FarmData.FarmListID) AS FarmListID,
                        COALESCE(FM.PresentOwner, CTE_FarmData.PresentOwner) AS PresentOwner,
                        COALESCE(FM.FarmNumber, CTE_FarmData.FarmNumber) AS FarmNumber,
                        COALESCE(FM.OriginalLandowner, CTE_FarmData.OriginalLandowner) AS OriginalLandowner,
                        COALESCE(FM.FarmName, CTE_FarmData.FarmName) AS FarmName,
                        COALESCE(FM.FirstName, CTE_FarmData.FirstName) AS FirstName,
                        COALESCE(FM.LastName, CTE_FarmData.LastName) AS LastName,


                        COALESCE(FM.Street1, CTE_FarmData.Street1) AS Street1,
                        COALESCE(FM.Street2, CTE_FarmData.Street2) AS Street2,
                        COALESCE(FM.City, CTE_FarmData.City) AS City,
                        COALESCE(FM.State, CTE_FarmData.State) AS State,
                        COALESCE(FM.ZipCode, CTE_FarmData.ZipCode) AS ZipCode,
                        COALESCE(FM.PhoneNumber, CTE_FarmData.PhoneNumber) AS PhoneNumber,
                        COALESCE(FM.FarmerName, CTE_FarmData.FarmerName) AS FarmerName,
                        COALESCE(FM.IsConservationPlan, CTE_FarmData.IsConservationPlan) AS IsConservationPlan,
                        COALESCE(FM.ConsPlanDate, CTE_FarmData.ConsPlanDate) AS ConsPlanDate,
                        COALESCE(FM.ConsPlanComment, CTE_FarmData.ConsPlanComment) AS ConsPlanComment,

                        --COALESCE(FM.ApplicationStatusId, CTE_FarmData.ApplicationStatusId) AS ApplicationStatusId,
                        --COALESCE(FM.MunicipalId, CTE_FarmData.MunicipalId) AS MunicipalId,
                        --COALESCE(FM.Block, CTE_FarmData.Block) AS Block,
                        --COALESCE(FM.Lot, CTE_FarmData.Lot) AS Lot,
                        --COALESCE(FM.PamsPin, CTE_FarmData.PamsPin) AS PamsPin,
                        --COALESCE(FM.Municipality, CTE_FarmData.Municipality) AS Municipality,
                        --COALESCE(FM.AddBlocks, CTE_FarmData.AddBlocks) AS AddBlocks,
                        --COALESCE(FM.AddLots, CTE_FarmData.AddLots) AS AddLots,

                        COALESCE(FM.ClosingDate, CTE_FarmData.ClosingDate) AS ClosingDate,
                        COALESCE(FM.TitlePolicy, CTE_FarmData.TitlePolicy) AS TitlePolicy,
                        COALESCE(FM.TitleCompany, CTE_FarmData.TitleCompany) AS TitleCompany,
                        COALESCE(FM.EPDeedBook, CTE_FarmData.EPDeedBook) AS EPDeedBook,
                        COALESCE(FM.EPDeedPage, CTE_FarmData.EPDeedPage) AS EPDeedPage,
                        COALESCE(FM.EPDeedFiled, CTE_FarmData.EPDeedFiled) AS EPDeedFiled,
                        COALESCE(FM.RDSOsNum, CTE_FarmData.RDSOsNum) AS RDSOsNum,
                        COALESCE(FM.IsRDSOExercised, CTE_FarmData.IsRDSOExercised) AS IsRDSOExercised,
                        COALESCE(FM.RDSOExplan, CTE_FarmData.RDSOExplan) AS RDSOExplan,
                        COALESCE(FM.ImprovRes, CTE_FarmData.ImprovRes) AS ImprovRes,
                        COALESCE(FM.AreNonAgUses, CTE_FarmData.AreNonAgUses) AS AreNonAgUses,
                        COALESCE(FM.ImprovAg, CTE_FarmData.ImprovAg) AS ImprovAg,
                        COALESCE(FM.NonAgExplan, CTE_FarmData.NonAgExplan) AS NonAgExplan,
                        COALESCE(FM.GrossAcers, CTE_FarmData.GrossAcers) AS GrossAcers

                        --COALESCE(FM.NetAcres, CTE_FarmData.NetAcres) AS NetAcres
                    FROM 
                        CTE_FarmData
                    LEFT JOIN 
                        Farm.FarmMonitoringDetails FM
                    ON 
                        (CTE_FarmData.FarmListID = FM.FarmListId AND CTE_FarmData.FarmName = FM.FarmName AND CTE_FarmData.FarmNumber = FM.FarmNumber);";

                public GetFarmMonitoringSqlQuery()
                {

                }

                public override string ToString()
                {
                    return _sqlCommand;
                }

}
