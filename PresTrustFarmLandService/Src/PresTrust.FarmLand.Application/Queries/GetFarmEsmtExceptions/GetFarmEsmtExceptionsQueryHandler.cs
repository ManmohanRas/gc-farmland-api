namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtExceptionsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtExceptionsQuery, GetFarmEsmtExceptionsQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtExceptionsRepository repoexceptionsDetails;
    private readonly IApplicationRepository repoApplication;
    
    public GetFarmEsmtExceptionsQueryHandler
       (
             IMapper mapper,
           IFarmEsmtExceptionsRepository repoexceptionsDetails,
           IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
         this.mapper = mapper;
         this.repoexceptionsDetails = repoexceptionsDetails;
         this.repoApplication = repoApplication;
    }


    public async Task<GetFarmEsmtExceptionsQueryViewModel> Handle(GetFarmEsmtExceptionsQuery request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);
    
        GetFarmEsmtExceptionsQueryViewModel result = new GetFarmEsmtExceptionsQueryViewModel();
    
        var reqExceptionDetails = await repoexceptionsDetails.GetEsmtExceptionsDetailsAsync(request.ApplicationId);
    
    
       result = mapper.Map<FarmEsmtExceptionsEntity, GetFarmEsmtExceptionsQueryViewModel>(reqExceptionDetails);
        return result;
    }
}
