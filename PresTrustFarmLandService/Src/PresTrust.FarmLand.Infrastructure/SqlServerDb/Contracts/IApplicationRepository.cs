namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IApplicationRepository
    {
        public Task<List<FarmLandApplicationEntity>> GetApplicationsAsync();
    }
}
