namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalFinanceQueryHandler : IRequestHandler<GetMunicipalFinanceQuery, GetMunicipalFinanceQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IMunicipalTrustFundPermittedUsesRepository repoMunicipalTrustFundPermittedUses;
    private readonly IMunicipalFinanceRepository repoFinance;

    public GetMunicipalFinanceQueryHandler(
               IMapper mapper,
               IMunicipalTrustFundPermittedUsesRepository repoMunicipalTrustFundPermittedUses,
               IMunicipalFinanceRepository repoFinance
        )
    {
        this.repoMunicipalTrustFundPermittedUses = repoMunicipalTrustFundPermittedUses;
        this.mapper = mapper;
        this.repoFinance = repoFinance;
    }
    public async Task<GetMunicipalFinanceQueryViewModel> Handle(GetMunicipalFinanceQuery request, CancellationToken cancellationToken)
    {
        var municipalTrustFundPermittedUses = await repoMunicipalTrustFundPermittedUses.GetMunicipalTrustFundPermittedUses(request.AgencyId);
        var municipalFinances = await repoFinance.GetMunicipalFinanceDetails(request.AgencyId);

        municipalTrustFundPermittedUses = municipalTrustFundPermittedUses ?? new FarmMunicipalTrustFundPermittedUsesEntity() { AgencyId = request.AgencyId };

        var result = mapper.Map<FarmMunicipalTrustFundPermittedUsesEntity, GetMunicipalFinanceQueryViewModel>(municipalTrustFundPermittedUses);
        if (municipalFinances.Count() > 0)
        {
            result.MunicipalFinances = municipalFinances;
        }

        return result;
    }
}
