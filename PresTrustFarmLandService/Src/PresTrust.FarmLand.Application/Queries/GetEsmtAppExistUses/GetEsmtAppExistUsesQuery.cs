namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQuery:IRequest<GetEsmtAppExistUsesQueryViewModel>
{
    public int ApplicationId { get; set; }

}
