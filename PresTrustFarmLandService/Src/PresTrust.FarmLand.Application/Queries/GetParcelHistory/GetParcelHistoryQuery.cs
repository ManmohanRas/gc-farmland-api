namespace PresTrust.FarmLand.Application.Queries;

public class GetParcelHistoryQuery: IRequest<List<GetParcelHistoryQueryViewModel>>
{
    public int ParcelId { get; set; }

}
