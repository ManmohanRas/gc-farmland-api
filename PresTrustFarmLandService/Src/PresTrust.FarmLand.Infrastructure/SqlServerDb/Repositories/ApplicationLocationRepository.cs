using Dapper;
using Microsoft.Data.SqlClient;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class ApplicationLocationRepository: IApplicationLocationRepository
{
    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public ApplicationLocationRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId = default)
    {
        List<FarmBlockLotEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetParcelsByFarmId();
        results = (await conn.QueryAsync<FarmBlockLotEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new 
                            { @p_ApplicationId = applicationId, 
                              @p_FarmListID  = farmListID,
                              @p_ApplicationTypeId = applicationTypeId,
                            })).ToList();
        return results ?? new();
    }

    public async Task<List<FarmBlockLotEntity>> GetUnLinkedParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId)
    {
        List<FarmBlockLotEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetUnLinkedParcelsByFarmId();
        results = (await conn.QueryAsync<FarmBlockLotEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                                @p_FarmListID = farmListID,
                                @p_applicationTypeId = applicationTypeId
                            })).ToList();
        return results ?? new();
    }

    public async Task<FarmAppLocationDetailsEntity> CheckLocationParcel(int applicationId,FarmAppLocationDetailsEntity parcel)
    {

        if (parcel.ApplicationId is 0)   
            return await SaveLocationDetailsAsync(applicationId, parcel);
        else
            return await UpdateLocationDetailssync(applicationId, parcel);
    }


    public async Task<FarmAppLocationDetailsEntity> SaveLocationDetailsAsync(int applicationId,  FarmAppLocationDetailsEntity parcel)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermAppLocationSqlCommand();
       var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
        commandType: CommandType.Text,
        commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                        param: new
                        {
                            @p_ApplicationId = applicationId,
                            @p_FarmListID = parcel.FarmListID,
                            @p_ParcelId = parcel.ParcelId,
                            @p_PamsPin = parcel.PamsPin,
                            @p_IsChecked = parcel.IsChecked,
                            @p_AcresToBeAcquired = parcel.AcresToBeAcquired,
                            @p_ExceptionAreaAcres = parcel.ExceptionAreaAcres,
                            @p_Notes = parcel.Notes,
                            @p_Acres = parcel.Acres,
                            @p_ExceptionArea = parcel.ExceptionArea
                        });

          parcel.ParcelId = id;
        return parcel;
    }



    public async Task<FarmAppLocationDetailsEntity> UpdateLocationDetailssync(int applicationId, FarmAppLocationDetailsEntity parcel)
    {
        using var conn = context.CreateConnection();
        var sqlcommand = new UpdateLocationDetailsSqlCommand();

        await conn.ExecuteScalarAsync(sqlcommand.ToString(), commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = applicationId,
                @p_FarmListID = parcel.FarmListID,
                @p_ParcelId = parcel.ParcelId,
                @p_PamsPin = parcel.PamsPin,
                @p_IsChecked = parcel.IsChecked,
                @p_AcresToBeAcquired = parcel.AcresToBeAcquired,
                @p_ExceptionAreaAcres = parcel.ExceptionAreaAcres,
                @p_Notes = parcel.Notes,
                @p_Acres = parcel.Acres,
                @p_ExceptionArea = parcel.ExceptionArea

            });

        return parcel;


    }

    public async Task<bool> DeleteTermAppLocationBlockLot(int applicationId, int parcelId)
    {

        using var conn = context.CreateConnection();
       
            var sqlCommand = new DeleteTermAppLocationBlockLotSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new
                                {
                                    @p_ApplicationId = applicationId,
                                    @p_ParcelId = parcelId
                                });
        
        return true;
    }




}
