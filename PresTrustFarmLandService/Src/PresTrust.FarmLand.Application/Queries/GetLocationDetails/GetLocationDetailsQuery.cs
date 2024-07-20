namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQuery: IRequest<GetLocationDetailsQueryViewModel>
{
    public int ApplicationId { get; set; }
    public int FarmListID { get; set; }
}
