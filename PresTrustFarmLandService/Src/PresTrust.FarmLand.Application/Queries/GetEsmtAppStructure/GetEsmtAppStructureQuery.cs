

namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppStructureQuery:IRequest<GetEsmtAppStructureQueryViewModel>
{
    public int ApplicationId { get; set; }
}
