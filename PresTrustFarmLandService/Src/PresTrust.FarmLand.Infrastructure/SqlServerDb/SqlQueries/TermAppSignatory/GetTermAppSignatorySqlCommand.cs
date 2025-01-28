namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetTermAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
        @"  SELECT 
                        TS.Id,
                        TS.ApplicationId,
                        TS.Designation,
                        TS.Title,
                        TS.SignedOn,
                        STUFF((
                            SELECT DISTINCT  ', ' + AG.AgencyName
                            FROM 
                                Farm.FarmMunicipalityBlockLotParcel BP
                            LEFT JOIN 
                                [Farm].[FarmAppLocationDetails] TL ON BP.Id = TL.ParcelId 
                            LEFT JOIN 
                                Core.View_AgencyEntities_FLOOD AG ON AG.AgencyId = BP.MunicipalityId 
                            WHERE 
                                TL.IsChecked = 1 AND TL.ApplicationId = TS.ApplicationId
                            FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Municipality,
                        TS.LastUpdatedBy,
                        TS.LastUpdatedOn  
                    FROM 
                        [Farm].[FarmTermAppSignature] TS
                    WHERE 
                       TS.ApplicationId = @p_ApplicationId
                    GROUP BY 
                        TS.Id,
                        TS.ApplicationId,
                        TS.Designation,
                        TS.Title,
                        TS.SignedOn,
                        TS.LastUpdatedBy,
                        TS.LastUpdatedOn;";


    public GetTermAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
