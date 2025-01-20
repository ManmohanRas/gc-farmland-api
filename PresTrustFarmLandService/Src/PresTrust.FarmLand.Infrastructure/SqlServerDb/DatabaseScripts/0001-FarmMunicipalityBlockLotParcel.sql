BEGIN TRY
	BEGIN TRANSACTION
	 
--===================================================================================================================================================
DROP TABLE IF EXISTS [FARM].[#FarmMunicipalityBlockLotParcel];

CREATE TABLE [FARM].[#FarmMunicipalityBlockLotParcel](
		[Id]                     INT                          NOT NULL
		,[MunicipalityId]        VARCHAR(4)                   NOT NULL
		,[FarmListId]            INT                          NOT NULL
		,[PropertyClassCode]     VARCHAR(50)                  NULL
		,[DeedBook]              VARCHAR(50)                  NULL
		,[DeedPage]              VARCHAR(50)                  NULL
		,[DeedDate]              DATETIME                     NULL
		,[Block]                 VARCHAR(50)                  NULL
		,[Lot]                   VARCHAR(50)                  NULL
		,[QualificationCode]     VARCHAR(50)                  NULL
		,[Section]               VARCHAR(128)                 NULL
		,[Partial]               BIT                          NULL
		,[Acres]                 DECIMAL(10,3)                NULL
		,[AcresToBeAcquired]     DECIMAL(10,3)                NULL
		,[ExceptionAreaAcres]    DECIMAL(10,3)                NULL
		,[ExceptionArea]         BIT                          NULL
		,[Notes]                 VARCHAR(4000)                NULL
		,[PamsPin]               VARCHAR(100)                 NULL
		,[IsValidFeatureId]      BIT                          NULL
		,[IsValidPamsPin]        BIT                          NULL
		,[InterestType]          VARCHAR(100)                 NULL
		,[EasementId]            VARCHAR(100)                 NULL
		,[ChangeType]            VARCHAR(100)                 NULL
		,[ChangeDate]            DATETIME                     NULL
		,[ReasonForChange]       VARCHAR(4000)                NULL
		,[IsActive]              BIT                          NULL
		,[Status]                VARCHAR(50)                  NULL
		,[IsWarning]             BIT                          NULL
		,[CreatedByProgramUser]  BIT                          NULL
		,[LastUpdatedBy]	     VARCHAR(128)			      NULL 
		,[LastUpdatedOn]	     Datetime				  NOT NULL, 
 );

WITH CoreParcelCTE AS
		
		(
			SELECT
				*
			FROM
			(
			SELECT Id, replace(block,'/',',')Block,replace(replace(replace(replace(replace(Lots,' & ',', & '),',, & ',','),', & ',','),' &',','),' and ',',') lot,
					[MunicipalId],
					[FarmListID],
					NULL AS [PropertyClassCode],
					ISNULL([Orig Book],0) AS [DeedBook],
					ISNULL([Orig Page],0) AS [DeedPage],
					NULL AS [DeedDate],
					NULL AS [QualificationCode],
					NULL AS [Section],
					NULL AS [Partial],
					[Acres],
					NULL AS [AcresToBeAcquired],
					NULL AS [ExceptionAreaAcres],
					NULL AS [ExceptionArea],
					NULL AS [Notes],
					NULL AS [PamsPin],
					NULL AS [IsValidFeatureId],
					NULL AS [IsValidPamsPin],
					NULL AS [InterestType],
					NULL AS [EasementId],
					NULL AS [ChangeType],
					NULL AS [ReasonForChange],
					NULL AS [IsActive],
					NULL AS [IsWarning],
					NULL AS [CreatedByProgramUser]
			FROM [Farm].[TermProgram_Legacy]  
			) CoreParcels
		)
		INSERT INTO [Farm].[FarmMunicipalityBlockLotParcel]
		(
			[MunicipalityId],                                                                                                                                                               
			[FarmListId],						                                                                                    
			[PropertyClassCode],                                                                                         
			[DeedBook],                                                                                                                                     
			[DeedPage],                         
			[DeedDate],                          
			[Block],                             
			[Lot],                               
			[QualificationCode],                 
			[Section],                           
			[Partial],							  
			[Acres],							 
			[AcresToBeAcquired],				  
			[ExceptionAreaAcres],				       
			[ExceptionArea],					 
			[Notes],							  
			[PamsPin],							
			[IsValidFeatureId],				  
			[IsValidPamsPin],					  
			[InterestType],					  
			[EasementId],						 
			[ChangeType],						  
			[ChangeDate],		                  
			[ReasonForChange],					  
			[IsActive],						  
			[IsWarning],						  
			[CreatedByProgramUser],
			[LastUpdatedBy],
			[LastUpdatedOn]
		)
		 SELECT 
					[MunicipalId],
					[FarmListID],
					NULL AS [PropertyClassCode],
					[DeedBook],
					[DeedPage],
					B.value as [Block],
					NULL AS [DeedDate],
					A.value as [Lot],--need to flatten 12,13&15
					NULL AS [QualificationCode],
					NULL AS [Section],
					NULL AS [Partial],
					[Acres],
					NULL AS [AcresToBeAcquired],
					NULL AS [ExceptionAreaAcres],
					NULL AS [ExceptionArea],
					NULL AS [Notes],
					NULL AS [PamsPin],
					NULL AS [IsValidFeatureId],
					NULL AS [IsValidPamsPin],
					NULL AS [InterestType],
					NULL AS [EasementId],
					NULL AS [ChangeType],
					NULL AS [ReasonForChange],
					NULL AS [IsActive],
					NULL AS [IsWarning],
					NULL AS [CreatedByProgramUser]
		FROM
		(
			SELECT *
			FROM CoreParcelCTE
			CROSS APPLY STRING_SPLIT(lot, ',') A
			CROSS APPLY STRING_SPLIT(Block,',') B
		) AS Parcel;

		
--===================================================================================================================================================
 
    --SELECT 1/0;  -- To avoid accidental runs
	COMMIT;
	PRINT 'Data Migrated successfully in FarmMunicipalityBlockLotParcel Table';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;
END CATCH
		