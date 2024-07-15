namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IFarmListRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FarmListEntity>> GetFarmListAsync();

        public Task<FarmListEntity> SaveFarmListAsync(FarmListEntity farmList);
    }
}
