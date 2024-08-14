namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtOwnerDetailsQuery : IRequest<GetEsmtOwnerDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
}
