namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetTermAppAdminDeedLocationDetails
    {
        private readonly string _sqlCommand =
          @"  SELECT    
                     [ApplicationId]
                    ,[ParcelId]
                    ,[DeedId]
                    ,[IsChecked]
                FROM [Farm].[FarmTermAppDeedLocation] 
                WHERE [ApplicationId] = @p_ApplicationId;"
   ;

        public GetTermAppAdminDeedLocationDetails()
        { }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
