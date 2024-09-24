namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtAgriculturalEnterpriseRepository
{
    Task<FarmEsmtAgriculturalEnterpriseEntity> GetAgriEnterprisAsync(int applicationId);

    Task<FarmEsmtAgriculturalEnterpriseEntity> SaveAsync(FarmEsmtAgriculturalEnterpriseEntity farmEsmtAgriEnterprise);

    //CHECK LIST
    Task<List<FarmAgriculturalEnterpriseChecklistEntity>> GetAgriCheckListAsync(int applicationId);

    Task<FarmAgriculturalEnterpriseChecklistEntity> SaveAgriCheckListAsync(FarmAgriculturalEnterpriseChecklistEntity agriCheckList);

}
