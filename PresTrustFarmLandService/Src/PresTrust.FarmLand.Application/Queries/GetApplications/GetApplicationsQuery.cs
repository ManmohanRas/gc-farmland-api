namespace PresTrust.FarmLand.Application.Queries
{
    public class GetApplicationsQuery: IRequest<List<GetApplicationsQueryViewModel>>
    {
        public string UserId { get; set; }
    }
}
