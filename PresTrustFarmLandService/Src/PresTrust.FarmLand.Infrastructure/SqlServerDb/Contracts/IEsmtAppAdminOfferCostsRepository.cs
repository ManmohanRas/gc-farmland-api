namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppAdminOfferCostsRepository
{
    public Task<EsmtAppAdminOfferCostsEntity> GetEsmtAppAdminOfferCostsAsync(int ApplicationId);

    public Task<EsmtAppAdminOfferCostsEntity> SaveEsmtAppAdminOfferCostsAsync(EsmtAppAdminOfferCostsEntity request);
}
