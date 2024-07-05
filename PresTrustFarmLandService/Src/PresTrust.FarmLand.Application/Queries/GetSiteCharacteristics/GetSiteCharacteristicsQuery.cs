namespace PresTrust.FarmLand.Application.Queries;

public class GetSiteCharacteristicsQuery: IRequest<GetSiteCharacteristicsQueryViewModel>
{

    public int ApplicationId { get; set; }

}
