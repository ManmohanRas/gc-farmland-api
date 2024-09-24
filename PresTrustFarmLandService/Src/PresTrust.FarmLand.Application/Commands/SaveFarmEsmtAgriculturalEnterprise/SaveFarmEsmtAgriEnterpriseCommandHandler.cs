using AutoMapper;
using static Dapper.SqlMapper;
using System.Net.Mail;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAgriEnterpriseCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtAgriEnterpriseCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtAgriculturalEnterpriseRepository repoAgricultural;


    public SaveFarmEsmtAgriEnterpriseCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmEsmtAgriculturalEnterpriseRepository repoAgricultural
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoAgricultural = repoAgricultural;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveFarmEsmtAgriEnterpriseCommand request, CancellationToken cancellationToken)
    {
        int aggriId = 0;
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtAgriculturalEnterpriseEntity
        var reqAgricultural = mapper.Map<SaveFarmEsmtAgriEnterpriseCommand, FarmEsmtAgriculturalEnterpriseEntity>(request);
        var reqAgriCheckList = new List<SaveFarmEsmtAgriCheckListViewModel>(request.AgriCheckList ?? new List<SaveFarmEsmtAgriCheckListViewModel>());
        reqAgricultural.LastUpdatedBy = userContext.Email;
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var aggricultura= await repoAgricultural.SaveAsync(reqAgricultural);
            await SaveAgriCheckList(reqAgriCheckList);
            if (aggricultura != null)
            {
                aggriId = aggricultura.Id;
            }
            scope.Complete();
        }
        return aggriId;
    }

    private async Task SaveAgriCheckList(IEnumerable<SaveFarmEsmtAgriCheckListViewModel> agriCheckLists)
    {
        foreach (var agriCheckList in agriCheckLists)
        {
            var entity = mapper.Map<SaveFarmEsmtAgriCheckListViewModel, FarmAgriculturalEnterpriseChecklistEntity>(agriCheckList);

            await repoAgricultural.SaveAgriCheckListAsync(entity);

        }
    }



}
