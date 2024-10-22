namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminStructNonAgWetlandsQuery : IRequest<GetFarmEsmtAppAdminStructNonAgWetlandsQueryViewModel>
{
    public int ApplicationId { get; set; }
}
