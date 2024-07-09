namespace PresTrust.FarmLand.Application.Queries
{
    public class GetTermAdminDetailsQuery : IRequest<GetTermAdminDetailsQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}
