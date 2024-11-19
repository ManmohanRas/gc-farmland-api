namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IFarmSadcAppEligibilityRepository
    {
        Task<FarmSadcAppEligibilityEntity> GetAppEligibilityDetailsAsync(int applicationId);

        Task<FarmSadcAppEligibilityEntity> SaveAsync(FarmSadcAppEligibilityEntity farmSadcAppEligibilityDetails);
    }
}
