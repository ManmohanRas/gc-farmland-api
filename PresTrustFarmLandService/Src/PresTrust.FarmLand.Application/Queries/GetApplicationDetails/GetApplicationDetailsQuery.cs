namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDetailsQuery: IRequest<GetApplicationDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }

}
