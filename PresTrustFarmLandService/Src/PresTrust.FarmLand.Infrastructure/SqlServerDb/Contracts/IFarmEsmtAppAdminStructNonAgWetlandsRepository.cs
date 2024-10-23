namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtAppAdminStructNonAgWetlandsRepository
{
    Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> GetStructNonAgWetlandsAsync(int applicationId);

    Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> SaveAsync(FarmEsmtAppAdminStructNonAgWetlandsEntity farmEsmtAppAdminStructNonAgWetlands);
}
