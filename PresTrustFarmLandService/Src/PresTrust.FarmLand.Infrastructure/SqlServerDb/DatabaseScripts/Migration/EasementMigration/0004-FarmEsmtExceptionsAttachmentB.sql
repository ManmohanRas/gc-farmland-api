BEGIN TRY
   BEGIN TRANSACTION

   ---Drop Table
   DROP TABLE IF EXISTS #FarmEsmtExceptionsAttachmentB

   -- Create Table
   CREATE TABLE #FarmEsmtExceptionsAttachmentB(
   [Id]                           [integer]      IDENTITY(1,1)     NOT NULL,
   [ApplicationId]                [integer]                        NOT NULL,
   [LocationOfException]          [varchar](256)                       NULL,
   [Block]                        [decimal](18,2)                      NULL,
   [Lot]                          [decimal](18,2)                      NULL,
   [ExceptionSize]                [decimal](18,2)                      NULL,
   [ReasonForException]           [varchar](256)                       NULL,
   [IsExceptionSoldFromPreserved] [bit]                                NULL,
   [IsRestrictExceptionToResiUnit][bit]                                NULL,
   [IsExceptionInNonAgriUse]      [bit]                                NULL,
   [IsResiExceptionArea]          [bit]                                NULL,
   [IsNonResiExceptionArea]       [bit]                                NULL,
   [NonAgriExceptionArea]         [varchar](256)                       NULL,
   [SingleFamilyResidence]        [integer]                            NULL,
   [ResiHomePermFoundation]       [integer]                            NULL,
   [ResiDuplex]                   [integer]                            NULL,
   [ResiHomeWithoutFoundation]    [integer]                            NULL,
   [ResidenceGarage]              [integer]                            NULL,
   [ResiDormitory]                [integer]                            NULL,
   [ResiAttachedTo]               [integer]                            NULL,
   [ResiGarriageHouse]            [integer]                            NULL,
   [NonResidentialBarn]           [integer]                            NULL,
   [NonResidentialShed]           [integer]                            NULL,
   [NonResidentialGarage]         [integer]                            NULL,
   [NonResidentialSilo]           [integer]                            NULL,
   [NonResidentialStable]         [integer]                            NULL,
   [LastUpdatedBy]				  [varchar](128)					   NULL, 
   [LastUpdatedOn]				  [datetime]					    NOT NULL

Constraint [PK_#FarmEsmtExceptionsAttachmentB_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script 

INSERT INTO #FarmEsmtExceptionsAttachmentB
            (
              ApplicationId
             ,LocationOfException
             ,Block
             ,Lot
             ,ExceptionSize
             ,ReasonForException
             ,IsExceptionSoldFromPreserved
             ,IsRestrictExceptionToResiUnit
             ,IsExceptionInNonAgriUse
             ,IsResiExceptionArea
             ,IsNonResiExceptionArea
             ,NonAgriExceptionArea
             ,SingleFamilyResidence
             ,ResiHomePermFoundation
             ,ResiDuplex
             ,ResiHomeWithoutFoundation
             ,ResidenceGarage
             ,ResiDormitory
             ,ResiAttachedTo
             ,ResiGarriageHouse
             ,NonResidentialBarn
             ,NonResidentialShed 
             ,NonResidentialGarage 
             ,NonResidentialSilo 
             ,NonResidentialStable
             ,LastUpdatedBy  
			 ,LastUpdatedOn
            )
			 SELECT
			  ProjectID
			 ,NULL AS LocationOfException
			 ,NULL AS Block
             ,NULL AS Lot
			 ,(Excep1Acres + Excep2Acres + Excep3Acres) AS ExceptionSize
			 ,NULL AS ReasonForException
			 ,CASE 
			      WHEN X1Severable ='Yes' THEN 1
			      WHEN X2IsSeverable = 'Yes' THEN 1
			      WHEN X3IsSeverable = 'Yes' THEN 1
			      ELSE 0
			  END AS IsExceptionSoldFromPreserved
			 ,NULL AS IsRestrictExceptionToResiUnit
			 ,CASE 
			      WHEN AreNonAgUses ='Yes' THEN 1
			      ELSE 0
			  END AS IsExceptionInNonAgriUse
			 ,NULL AS IsResiExceptionArea
			 ,NULL AS IsNonResiExceptionArea
             ,TRY_CAST(NonAgExplan AS NVARCHAR(MAX)) AS NonAgriExceptionArea
			 ,NULL AS SingleFamilyResidence
             ,NULL AS ResiHomePermFoundation
             ,NULL AS ResiDuplex
             ,NULL AS ResiHomeWithoutFoundation
             ,NULL AS ResidenceGarage
             ,NULL AS ResiDormitory
             ,NULL AS ResiAttachedTo
             ,NULL AS ResiGarriageHouse
             ,NULL AS NonResidentialBarn
             ,NULL AS NonResidentialShed 
             ,NULL AS NonResidentialGarage 
             ,NULL AS NonResidentialSilo 
             ,NULL AS NonResidentialStable
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application FarmEsmtExceptionsAttachmentB Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH