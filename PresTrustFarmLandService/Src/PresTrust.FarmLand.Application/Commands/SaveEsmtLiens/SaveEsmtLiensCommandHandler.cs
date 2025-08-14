using AutoMapper;

namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtLiensCommandHandler : BaseHandler, IRequestHandler<SaveEsmtLiensCommand, int>
    {
        private IMapper mapper;
        private readonly IPresTrustUserContext userContext;
        private readonly SystemParameterConfiguration systemParamOptions;
        private readonly IApplicationRepository repoApplication;
        private IEsmtLiensReposioty repoLiens;
        public SaveEsmtLiensCommandHandler
       (
       IMapper mapper,
       IPresTrustUserContext userContext,
       IOptions<SystemParameterConfiguration> systemParamOptions,
       IApplicationRepository repoApplication,
       IEsmtLiensReposioty repoLiens
        ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.userContext = userContext;
            this.systemParamOptions = systemParamOptions.Value;
            this.repoApplication = repoApplication;
            this.repoLiens = repoLiens;
        }

        public async Task<int> Handle(SaveEsmtLiensCommand request, CancellationToken cancellationToken)
        {
            userContext.DeriveUserProfileFromUserId(request.UserId);
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqEsmtLiens = mapper.Map<SaveEsmtLiensCommand, EsmtLiensEntity>(request);

            reqEsmtLiens = await repoLiens.SaveLiensAsync(reqEsmtLiens);

            return reqEsmtLiens.Id;

        }
    }
}
