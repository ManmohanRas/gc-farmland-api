BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtSadcResidence
 
-- Create Table
CREATE TABLE #FarmEsmtSadcResidence(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[IsAgriculturalLabor]			[bit]						        NULL,
	[UnitsUsedForLabor]			    [varchar](4000)						NULL,
	[Occupants]			            [int]					            NULL,
	[MonthsOccupied]			    [int]				                NULL,
	[IsOccupantsWork]				[bit]						        NULL,
	[PleaseExplain]					[varchar](4000)					    NULL,
	[IsResidencesRented]		    [bit]					            NULL,
	[RDSOsReserve]				    [varchar](4000)						NULL,
    [ExcepAcres1]                   [decimal](10,2)                     NULL,
    [NonSeverable1]                 [bit]                               NULL,
    [Severable1]                    [bit]                               NULL,
    [AdditionalComment1]           [varchar](4000)                      NULL,
    [ExcepAcres2]                   [decimal](10,2)                     NULL,
    [NonSeverable2]                 [bit]                               NULL,
    [Severable2]                    [bit]                               NULL,
    [AdditionalComment2]           [varchar](4000)                      NULL,
    [EsmtOthersText]                [varchar](4000)                     NULL,
    [IsSightTriangle]               [bit]                               NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_#FarmEsmtSadcResidence_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtSadcResidence
INSERT INTO #FarmEsmtSadcResidence
            (
			  ApplicationId
			 ,IsAgriculturalLabor
			 ,UnitsUsedForLabor
			 ,Occupants
			 ,MonthsOccupied
			 ,IsOccupantsWork
			 ,PleaseExplain
			 ,IsResidencesRented
			 ,RDSOsReserve
			 ,ExcepAcres1
			 ,NonSeverable1
			 ,Severable1
			 ,AdditionalComment1
			 ,ExcepAcres2
			 ,NonSeverable2
			 ,Severable2
			 ,AdditionalComment2
			 ,EsmtOthersText
			 ,IsSightTriangle
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		      ProjectID
			 ,NULL AS IsAgriculturalLabor
			 ,NULL AS UnitsUsedForLabor
			 ,NULL AS Occupants
			 ,NULL AS MonthsOccupied
			 ,NULL AS IsOccupantsWork
			 ,NULL AS PleaseExplain
			 ,NULL AS IsResidencesRented
			 ,NULL AS RDSOsReserve
			 ,Excep1Acres
			 ,CASE 
			      WHEN X1Severable = 'No' THEN 1
				  WHEN X1Severable = 'Yes' THEN 0
			      ELSE NULL
			   END AS NonSeverable1
			 ,CASE 
			      WHEN X1Severable = 'Yes' THEN 1
				  WHEN X1Severable = 'No' THEN 0
				  ELSE NULL
              END AS Severable1
			 ,X1Purpose
			 ,Excep2Acres
			 ,CASE
			      WHEN X2IsSeverable = 'No' THEN 1
				  WHEN X2IsSeverable = 'Yes' THEN 0
				  ELSE NULL
              END AS NonSeverable2
			 ,CASE 
			      WHEN X2IsSeverable = 'Yes' THEN 1
				  WHEN X2IsSeverable = 'No' THEN 0
				  ELSE NULL
              END AS Severable2
			 ,X2Purpose
			 ,NULL AS EsmtOthersText
			 ,NULL AS IsSightTriangle
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application SADC Residence Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH