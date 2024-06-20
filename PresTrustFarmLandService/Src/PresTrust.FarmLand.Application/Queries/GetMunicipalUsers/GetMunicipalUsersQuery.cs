namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalUsersQuery : IRequest<IEnumerable<PresTrustUserEntity>>
{
    public int AgencyId {get; set; }
}
