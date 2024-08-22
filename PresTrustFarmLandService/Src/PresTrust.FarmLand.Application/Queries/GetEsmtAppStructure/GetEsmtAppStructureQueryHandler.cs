namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppStructureQueryHandler: BaseHandler, IRequestHandler<GetEsmtAppStructureQuery,GetEsmtAppStructureQueryViewModel>
{
    IMapper mapper;
    public IEsmtAppStructureRepository repoStructure;
    private readonly IApplicationRepository repoApplication;

    public GetEsmtAppStructureQueryHandler(
        IMapper mapper,
        IEsmtAppStructureRepository repostructure,
        IApplicationRepository repoApplication):base(repoApplication:repoApplication)
    {
        this.mapper = mapper;
        this.repoStructure = repostructure;
        this.repoApplication =repoApplication;

    }

    public async Task<GetEsmtAppStructureQueryViewModel> Handle(GetEsmtAppStructureQuery request, CancellationToken cancellationToken)
    {
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);
        
        var structure = await repoStructure.GetEsmtStructureEntityAsync(application.Id);
        var results = mapper.Map<EsmtStructureAppEntity,GetEsmtAppStructureQueryViewModel>(structure);  
        return results;

       
    }
}
