namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmSadcResidenceRepository
{
    Task<FarmSadcResidenceEntity> GetSadcResidenceAsync(int applicationId);

    Task<FarmSadcResidenceEntity> SaveAsync(FarmSadcResidenceEntity farmSadcResidence);
}
