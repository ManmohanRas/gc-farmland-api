namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppSignatoryQuery : IRequest<GetEsmtAppSignatoryQueryViewModel>
{
    public int ApplicationId { get; set; }
}
