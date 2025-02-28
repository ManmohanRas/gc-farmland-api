using Microsoft.Data.SqlClient;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppAdminDeedDetailsSqlCommand
{
    private readonly string _sqlCommand =
       @" SELECT DISTINCT	 
                     AD.Id AS Id 
                    ,DL.[ApplicationId]
					,DL.ParcelId AS ParcelId
                    ,MBL.MunicipalityId
                    ,CM.Municipality
                    ,MBL.QualificationCode
                    ,MBL.[Block] AS OriginalBlock
                    ,MBL.[Lot] AS OriginalLot
                    ,AD.[OriginalBook]
                    ,AD.[OriginalPage]
                    ,AD.[NOTBook]						
                    ,AD.[NOTPage]						
                    ,AD.[RDBook]						
                    ,AD.[RDPage]	
					,DL.IsChecked AS IsChecked
                    ,AD.[LastUpdatedBy]
                    ,AD.[LastUpdatedOn]

                FROM [Farm].[FarmTermAppDeedLocation]  AS DL
                LEFT JOIN   [Farm].[FarmMunicipalityBlockLotParcel]  AS  MBL ON (DL.ParcelId = MBL.Id)
				LEFT JOIN [Farm].[FarmTermAppDeedDetails] AS AD ON (DL.ParcelId = AD.ParcelId)
                LEFT JOIN [Core].[Municipality] CM ON (MBL.MunicipalityId = CM.MunicipalId AND CM.InCounty = 1)
                WHERE DL.IsChecked = 1  AND DL.ApplicationId = @p_ApplicationId;";
   
    public GetTermAppAdminDeedDetailsSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
