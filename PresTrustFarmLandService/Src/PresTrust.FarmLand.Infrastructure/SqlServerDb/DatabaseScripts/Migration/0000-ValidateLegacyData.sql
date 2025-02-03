--Check1:
;WITH cte_farmlist AS  
(
	SELECT DISTINCT 
		FarmListId,
		ISNULL(FarmName, '') AS FarmName
	FROM [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02]
	WHERE ISNULL(FarmName,'') <> ''
),
cte_farmlist_duplicates AS  
(
	SELECT		distinct FarmListId 
	FROM		cte_farmlist
	GROUP BY	FarmListId
	HAVING COUNT(*) > 1
)
SELECT ownerprop.FarmListId, ownerprop.FarmName FROM [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02] ownerprop
INNER JOIN cte_farmlist_duplicates cte on (cte.FarmListId = ownerprop.FarmListId)
ORDER BY FarmListID desc

--UPDATE [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02]
--SET		FarmName = 'Charters Farm'
--WHERE	FarmListID = 5;

--UPDATE [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02]
--SET		FarmName = 'Perkoski Farm'
--WHERE	FarmListID = 199;

--UPDATE [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02]
--SET		FarmName = 'Kincaid Farm'
--WHERE	FarmListID = 95;