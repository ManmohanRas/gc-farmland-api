namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminExceptionRDSOQuery : IRequest<GetEsmtAppAdminExceptionRDSOQueryViewModel>
{
    public int ApplicationId { get; set; }
}
