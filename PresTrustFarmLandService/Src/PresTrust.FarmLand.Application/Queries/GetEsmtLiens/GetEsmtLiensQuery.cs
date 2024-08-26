namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtLiensQuery : IRequest<GetEsmtLiensQueryViewModel>
{
    public int ApplicationId { get; set; }
}
