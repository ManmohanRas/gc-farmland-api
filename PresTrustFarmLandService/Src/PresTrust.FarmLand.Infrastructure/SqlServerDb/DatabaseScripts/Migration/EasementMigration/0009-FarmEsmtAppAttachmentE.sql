BEGIN TRY
   BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtAppAttachmentE

--CREATE TABLE
CREATE TABLE #FarmEsmtAppAttachmentE(

   [Id]													   [integer] 		IDENTITY(1,1)      NOT NULL,
   [ApplicationId]                                         [integer]                           NOT NULL,
   [TypeOfDevelopment]                                     [varchar](128)                          NULL,
   [PreliminaryApprovalDate]                               [dateTime]                              NULL,   
   [FinalApprovalDate]                                     [dateTime]                              NULL,   
   [ScaleofSubdivision]                                    [varchar](50)                           NULL,   
   [OtherPertinentInformation]                             [varchar](4000)                         NULL, 
   [IsOpenEnrollment]                                      [bit]                                   NULL,   
   [IsPropertyOutlined]                                    [bit]                                   NULL,   
   [IsAllExpAreasIdentified]                               [bit]                                   NULL,   
   [IsAllNonAgriEquiUsesDetailed]                          [bit]                                   NULL,   
   [IsCopyOfDeed]                                          [bit]                                   NULL,   
   [IsSignOfAllPropOwnersListed]                           [bit]                                   NULL,   
   [IsFarmLandAssReportCopy]                               [bit]                                   NULL,   
   [LastUpdatedBy]										   [varchar](128)		                   NULL, 
   [LastUpdatedOn]				                           [datetime]			                NOT NULL
   CONSTRAINT [PK_#FarmEsmtAppAttachmentE_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--Insert Script For #FarmEsmtAppAttachmentE
INSERT INTO #FarmEsmtAppAttachmentE 
            (  
			  ApplicationId
             ,TypeOfDevelopment
             ,PreliminaryApprovalDate
             ,FinalApprovalDate
             ,ScaleofSubdivision
             ,OtherPertinentInformation
             ,IsOpenEnrollment
             ,IsPropertyOutlined
             ,IsAllExpAreasIdentified
             ,IsAllNonAgriEquiUsesDetailed
             ,IsCopyOfDeed
             ,IsSignOfAllPropOwnersListed
             ,IsFarmLandAssReportCopy
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			SELECT
			  ProjectID
			 ,NULL AS TypeOfDevelopment
             ,NULL AS PreliminaryApprovalDate
             ,NULL AS FinalApprovalDate
             ,NULL AS ScaleofSubdivision
             ,NULL AS OtherPertinentInformation
             ,NULL AS IsOpenEnrollment
             ,NULL AS IsPropertyOutlined
             ,NULL AS IsAllExpAreasIdentified
             ,NULL AS IsAllNonAgriEquiUsesDetailed
             ,NULL AS IsCopyOfDeed
             ,NULL AS IsSignOfAllPropOwnersListed
             ,NULL AS IsFarmLandAssReportCopy
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application FarmEsmtAppAttachmentE Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH