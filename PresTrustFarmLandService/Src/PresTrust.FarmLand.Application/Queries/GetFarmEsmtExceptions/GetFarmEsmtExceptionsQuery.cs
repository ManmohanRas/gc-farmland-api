namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtExceptionsQuery : IRequest<GetFarmEsmtExceptionsQueryViewModel>
{
    public int ApplicationId { get; set; }
}

