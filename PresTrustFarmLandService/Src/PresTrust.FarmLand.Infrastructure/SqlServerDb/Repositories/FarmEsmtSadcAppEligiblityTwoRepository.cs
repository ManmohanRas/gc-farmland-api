
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class FarmEsmtSadcAppEligiblityTwoRepository : IFarmEsmtSadcAppEligiblityTwoRepository
{
    private PresTrustSqlDbContext context;
    private SystemParameterConfiguration configuration;
    public FarmEsmtSadcAppEligiblityTwoRepository
    (
    PresTrustSqlDbContext context,
    IOptions<SystemParameterConfiguration> configuration
    )
    {
       this.context = context;
       this.configuration = configuration.Value;
    }
    public async Task<FarmEsmtSadcAppEligiblityTwoEntity> GetSadcEligiblityTwoAsync(int ApplicationId)
    {
        FarmEsmtSadcAppEligiblityTwoEntity eligiblityTwo = default;
        using var connection = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtSadcAppEligiblityTwoSqlCommand();
        var result = await connection.QueryAsync<FarmEsmtSadcAppEligiblityTwoEntity>
            (sqlCommand.ToString(),
              commandType: CommandType.Text,
              commandTimeout: configuration.SQLCommandTimeoutInSeconds,
              param: new { @p_ApplicationId = ApplicationId }
            );
        eligiblityTwo= result.FirstOrDefault();
        return eligiblityTwo ?? new ();
    }

    public async Task<FarmEsmtSadcAppEligiblityTwoEntity> SaveSadcEligibilityTwoAsync(FarmEsmtSadcAppEligiblityTwoEntity request)
    {

        if (request.Id > 0)
        {
            return await UpdateAsync(request);
        }
        else 
        {
            return await SaveAsync(request);
        }
    }


    public async Task<FarmEsmtSadcAppEligiblityTwoEntity> SaveAsync(FarmEsmtSadcAppEligiblityTwoEntity EligiblityTwo)
    {
        using var connection = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtSadcAppEligiblityTwoSqlCommand();
        var Id =await connection.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: configuration.SQLCommandTimeoutInSeconds,           
                param: new
                {
                    @p_ApplicationId = EligiblityTwo.ApplicationId,
                    @p_Prime = EligiblityTwo.Prime,
                    @p_PrimeacresPct = EligiblityTwo.PrimeacresPct,
                    @p_Statewide = EligiblityTwo.Statewide,
                    @p_StatewideAcresPct = EligiblityTwo.StatewideAcresPct,
                    @p_Local = EligiblityTwo.Local,
                    @p_LocalAcresPct = EligiblityTwo.LocalAcresPct,
                    @p_Unique = EligiblityTwo.Unique,
                    @p_UniqueAcresPct = EligiblityTwo.UniqueAcresPct,
                    @p_UniqueSoils = EligiblityTwo.UniqueSoils,
                    @p_ListCropUniqueSoil = EligiblityTwo.ListCropUniqueSoil,
                    @p_Other = EligiblityTwo.Other,
                    @p_OtherAcresPct = EligiblityTwo.OtherAcresPct,
                    @p_TotalNetAcres = EligiblityTwo.TotalNetAcres,
                    @p_TotalNetAcresPct = EligiblityTwo.TotalNetAcresPct,
                    @p_CroplandHarvested = EligiblityTwo.CroplandHarvested,
                    @p_CroplandHarvestedPct = EligiblityTwo.CroplandHarvestedPct,
                    @p_CroplandPastured = EligiblityTwo.CroplandPastured,
                    @p_CroplandPasturedPct = EligiblityTwo.CroplandPasturedPct,
                    @p_PermanentPasture = EligiblityTwo.PermanentPasture,
                    @p_PermanentPasturePct = EligiblityTwo.PermanentPasturePct,
                    @p_Woodlands = EligiblityTwo.Woodlands,
                    @p_WoodlandsPct = EligiblityTwo.WoodlandsPct,
                    @p_ExceptionOther = EligiblityTwo.ExceptionOther,
                    @p_ExceptionOtherPct = EligiblityTwo.ExceptionOtherPct,
                    @p_ExceptionTotalNetAcres = EligiblityTwo.ExceptionTotalNetAcres,
                    @p_ExceptionTotalNetAcresPct = EligiblityTwo.ExceptionTotalNetAcresPct,
                    @p_ZoningCode = EligiblityTwo.ZoningCode,
                    @p_MinimumLotSize = EligiblityTwo.MinimumLotSize,
                    @p_Regional = EligiblityTwo.Regional,
                    @p_IsHighlandsRegion = EligiblityTwo.IsHighlandsRegion,
                    @p_IsPreservation = EligiblityTwo.IsPreservation,
                    @p_IsPlanningArea = EligiblityTwo.IsPlanningArea,
                    @p_CountyaverageRank = EligiblityTwo.CountyaverageRank,
                    @p_LastUpdatedBy = EligiblityTwo.LastUpdatedBy,
                    @p_LastUpdatedOn = DateTime.Now,
                 }
        );
          EligiblityTwo.Id = Id;
          return EligiblityTwo;
    }

    public async Task<FarmEsmtSadcAppEligiblityTwoEntity> UpdateAsync(FarmEsmtSadcAppEligiblityTwoEntity EligiblityTwo)
    {
        using var connection = context.CreateConnection();
        var SqlCommand = new UpdateFarmEsmtSadcAppEligiblityTwoSqlCommand();
        var result = await connection.ExecuteAsync(SqlCommand.ToString(), 
            commandTimeout:configuration.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = EligiblityTwo.Id,
                @p_ApplicationId = EligiblityTwo.ApplicationId,
                @p_Prime = EligiblityTwo.Prime,
                @p_PrimeacresPct = EligiblityTwo.PrimeacresPct,
                @p_Statewide = EligiblityTwo.Statewide,
                @p_StatewideAcresPct = EligiblityTwo.StatewideAcresPct,
                @p_Local = EligiblityTwo.Local,
                @p_LocalAcresPct = EligiblityTwo.LocalAcresPct,
                @p_Unique = EligiblityTwo.Unique,
                @p_UniqueAcresPct = EligiblityTwo.UniqueAcresPct,
                @p_UniqueSoils = EligiblityTwo.UniqueSoils,
                @p_ListCropUniqueSoil = EligiblityTwo.ListCropUniqueSoil,
                @p_Other = EligiblityTwo.Other,
                @p_OtherAcresPct = EligiblityTwo.OtherAcresPct,
                @p_TotalNetAcres = EligiblityTwo.TotalNetAcres,
                @p_TotalNetAcresPct = EligiblityTwo.TotalNetAcresPct,
                @p_CroplandHarvested = EligiblityTwo.CroplandHarvested,
                @p_CroplandHarvestedPct = EligiblityTwo.CroplandHarvestedPct,
                @p_CroplandPastured = EligiblityTwo.CroplandPastured,
                @p_CroplandPasturedPct = EligiblityTwo.CroplandPasturedPct,
                @p_PermanentPasture = EligiblityTwo.PermanentPasture,
                @p_PermanentPasturePct = EligiblityTwo.PermanentPasturePct,
                @p_Woodlands = EligiblityTwo.Woodlands,
                @p_WoodlandsPct = EligiblityTwo.WoodlandsPct,
                @p_ExceptionOther = EligiblityTwo.ExceptionOther,
                @p_ExceptionOtherPct = EligiblityTwo.ExceptionOtherPct,
                @p_ExceptionTotalNetAcres = EligiblityTwo.ExceptionTotalNetAcres,
                @p_ExceptionTotalNetAcresPct = EligiblityTwo.ExceptionTotalNetAcresPct,
                @p_ZoningCode = EligiblityTwo.ZoningCode,
                @p_MinimumLotSize = EligiblityTwo.MinimumLotSize,
                @p_Regional = EligiblityTwo.Regional,
                @p_IsHighlandsRegion = EligiblityTwo.IsHighlandsRegion,
                @p_IsPreservation = EligiblityTwo.IsPreservation,
                @p_IsPlanningArea = EligiblityTwo.IsPlanningArea,
                @p_CountyaverageRank = EligiblityTwo.CountyaverageRank,
                @p_LastUpdatedBy = EligiblityTwo.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            }
        );
        return EligiblityTwo;
    }
}
