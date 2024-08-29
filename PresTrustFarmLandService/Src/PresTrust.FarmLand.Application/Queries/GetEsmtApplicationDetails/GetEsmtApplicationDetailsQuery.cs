namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtApplicationDetailsQuery: IRequest<GetEsmtApplicationDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }

}
