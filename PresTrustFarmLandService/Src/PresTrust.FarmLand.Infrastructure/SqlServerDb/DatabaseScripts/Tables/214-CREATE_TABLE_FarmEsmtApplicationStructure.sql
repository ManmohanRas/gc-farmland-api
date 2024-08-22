IF OBJECT_ID('[Farm].[FarmEsmtAppStructure]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppStructure];
		
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppStructure];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppStructure]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppStructure](
	[Id]						               	[integer] 		              IDENTITY(1,1) NOT NULL,
	[ApplicationId]					            [integer]						            NOT NULL,
	[IsResipreserved]							[bit]					                        NULL,
	[StdSingleFamilyResidence]					[varchar](128)			        			    NULL, 
	[MfWithHomePermFoundation]					[varchar](128)						            NULL, 	                                                                                                                                                    
    [Duplex]		                            [varchar](128)						            NULL, 
	[MfWithOutHomePermFoundation]				[varchar](128)						            NULL,
	[ResiGarage]		                        [varchar](128)						            NULL, 
	[Dormitory]		                            [varchar](128)						            NULL, 
	[ApartmentAttachedTo]		                [varchar](128)						            NULL, 
	[CarriageHouseOrCabin]		                [varchar](128)						            NULL, 
	[ResiOther]		                            [varchar](4000)						            NULL, 
	[UnitsAgricuturalLabor]						[varchar](4000)						            NULL, 
	[UnitsRentedOrLease]		                [varchar](4000)						            NULL, 
	[IsNonResiStructure]						[bit]						                    NULL, 
	[Barn]		                                [varchar](128)						            NULL, 
	[Shed]		                                [varchar](128)						            NULL, 
	[NonResiGarage]		                        [varchar](128)						            NULL, 
	[Silo]		                                [varchar](128)						            NULL, 
	[Stable]		                            [varchar](128)						            NULL, 
	[NonResiOther]		                        [varchar](128)						            NULL, 
	[IsHistBuildingOrStructure]					[bit]						                    NULL, 
	[HistoricSignificance]		                [varchar](4000)						            NULL, 
	[LastUpdatedBy]					            [varchar](128)					                NULL, 
	[LastUpdatedOn]					            [DateTime]					               	NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppStructure_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppStructure] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppStructure]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppStructure] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppStructure]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  
