namespace PresTrust.FarmLand.Application.Queries.GetEsmtLiens
{
    public class GetEsmtLiensQueryCommandHandler : BaseHandler, IRequestHandler<GetEsmtLiensQuery, GetEsmtLiensQueryViewModel>
    {
        private IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private IEsmtLiensReposioty repoliens;

        public GetEsmtLiensQueryCommandHandler(
           IMapper mapper,
           IApplicationRepository repoApplication,
           IEsmtLiensReposioty repoliens
          ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoApplication = repoApplication;
            this.repoliens = repoliens;
        }
        public async Task<GetEsmtLiensQueryViewModel> Handle(GetEsmtLiensQuery request, CancellationToken cancellationToken)
        {
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);


            var results = await this.repoliens.GetLiensAsync(request.ApplicationId);

            var liens = mapper.Map<EsmtLiensEntity, GetEsmtLiensQueryViewModel>(results);


            return liens;
        }
    }
}

