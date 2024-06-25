namespace PresTrust.FarmLand.Application.Queries;

public class GetOwnerDetailsQuery : IRequest<GetOwnerDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
}
