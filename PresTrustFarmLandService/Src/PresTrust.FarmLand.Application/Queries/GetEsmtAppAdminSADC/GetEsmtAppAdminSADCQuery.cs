namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQuery : IRequest<GetEsmtAppAdminSADCQueryViewModel>
{
    public int ApplicationId { get; set; }
}
