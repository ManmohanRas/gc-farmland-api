namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmSadcResidenceQuery : IRequest<GetFarmSadcResidenceQueryViewModel>
{
    public int ApplicationId { get; set; }
}
