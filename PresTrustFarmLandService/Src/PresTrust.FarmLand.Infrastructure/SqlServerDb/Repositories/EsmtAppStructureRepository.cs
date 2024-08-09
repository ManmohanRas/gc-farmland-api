
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class EsmtAppStructureRepository : IEsmtAppStructureRepository
{
    #region "..members."
    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParameterConfiguration;
    #endregion

    #region " ctor ... "

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public EsmtAppStructureRepository(
     PresTrustSqlDbContext context,
     IOptions< SystemParameterConfiguration> systemParameterConfiguration)
    {
        this.context = context;
        this.systemParameterConfiguration = systemParameterConfiguration.Value;

    }
    #endregion
    public async Task<EsmtStructureAppEntity> GetEsmtStructureEntityAsync(int applicationId)
    {
        EsmtStructureAppEntity  result= default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtAppStructureSqlCommand();
        var results = await conn.QueryAsync<EsmtStructureAppEntity>(sqlCommand.ToString(),
                                             commandType:CommandType.Text,
                                             commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
                                             param: new {@p_ApplicationId = applicationId});

        result = results.FirstOrDefault();
        return  result ?? new ();
    }

    public async Task<EsmtStructureAppEntity> SaveEsmtStructureEntityAsync(EsmtStructureAppEntity structure)
    {
        if (structure.Id > 0)
        {
            return await UpdateAsync(structure);

        }
        else {
            return await SaveAsync(structure);
        }
    }


    public async Task<EsmtStructureAppEntity> SaveAsync(EsmtStructureAppEntity structure)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtAppStructureSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType:CommandType.Text,
            commandTimeout:systemParameterConfiguration.SQLCommandTimeoutInSeconds,
           param: new
          {
           @p_ApplicationId = structure.ApplicationId,
           @p_IsResipreserved = structure.IsResipreserved,
           @p_StdSingleFamilyResidence = structure.StdSingleFamilyResidence,
           @p_MfWithHomePermFoundation = structure.MfWithHomePermFoundation,
           @p_Duplex = structure.Duplex,
           @p_MfWithOutHomePermFoundation = structure.MfWithOutHomePermFoundation,
           @p_ResiGarage = structure.ResiGarage,
           @p_Dormitory = structure.Dormitory,
           @p_ApartmentAttachedTo = structure.ApartmentAttachedTo,
           @p_CarriageHouseOrCabin = structure.CarriageHouseOrCabin,
           @p_ResiOther = structure.ResiOther,
           @p_UnitsAgricuturalLabor = structure.UnitsAgricuturalLabor,
           @p_UnitsRentedOrLease = structure.UnitsRentedOrLease,
           @p_IsNonResiStructure  = structure.IsNonResiStructure,
           @p_Barn = structure.Barn,
           @p_Shed = structure.Shed,
           @p_NonResiGarage = structure.NonResiGarage,
           @p_Silo = structure.Silo,
           @p_Stable = structure.Stable,
           @p_NonResiOther = structure.NonResiOther,
           @p_IsHistBuildingOrStructure = structure.IsHistBuildingOrStructure,
           @p_HistoricSignificance = structure.HistoricSignificance,
           @p_LastUpdatedBy = structure.LastUpdatedBy
         });
         structure.Id = id;
        return structure;

    }


    public async Task<EsmtStructureAppEntity> UpdateAsync(EsmtStructureAppEntity structure)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppStructureSqlCommand();

        await conn.ExecuteAsync(sqlCommand.ToString(),
       commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
        param: new
        {
           @p_Id = structure.Id,
           @p_ApplicationId = structure.ApplicationId,
           @p_IsResipreserved = structure.IsResipreserved,
           @p_StdSingleFamilyResidence = structure.StdSingleFamilyResidence,
           @p_MfWithHomePermFoundation = structure.MfWithHomePermFoundation,
           @p_Duplex = structure.Duplex,
           @p_MfWithOutHomePermFoundation = structure.MfWithOutHomePermFoundation,
           @p_ResiGarage = structure.ResiGarage,
           @p_Dormitory = structure.Dormitory,
           @p_ApartmentAttachedTo = structure.ApartmentAttachedTo,
           @p_CarriageHouseOrCabin = structure.CarriageHouseOrCabin,
           @p_ResiOther = structure.ResiOther,
           @p_UnitsAgricuturalLabor = structure.UnitsAgricuturalLabor,
           @p_UnitsRentedOrLease = structure.UnitsRentedOrLease,
           @p_IsNonResiStructure = structure.IsNonResiStructure,
           @p_Barn = structure.Barn,
           @p_Shed = structure.Shed,
           @p_NonResiGarage = structure.NonResiGarage,
           @p_Silo = structure.Silo,
           @p_Stable = structure.Stable,
           @p_NonResiOther = structure.NonResiOther,
           @p_IsHistBuildingOrStructure = structure.IsHistBuildingOrStructure,
           @p_HistoricSignificance = structure.HistoricSignificance,
           @p_LastUpdatedBy = structure.LastUpdatedBy,
           @p_LastUpdatedOn = DateTime.Now

         });
        return structure;
    }
           

}
