namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IFarmEsmtSadcAppEligiblityTwoRepository
{
    /// <summary>
    /// Get Exceptions Details
    /// </summary>
    /// <param name="ApplicationId"></param>
    /// <returns></returns>
    public Task<FarmEsmtSadcAppEligiblityTwoEntity> GetSadcEligiblityTwoAsync(int ApplicationId);

    /// <summary>
    /// SaveEsmtSadcFarmInfo
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<FarmEsmtSadcAppEligiblityTwoEntity> SaveSadcEligibilityTwoAsync(FarmEsmtSadcAppEligiblityTwoEntity request);
}
