namespace PresTrust.FarmLand.Application.Queries
{
    public class GetAttachmentDQueryHandler :BaseHandler, IRequestHandler<GetAttachmentDQuery, GetAttachmentDQueryViewModel>
    {
        private readonly IMapper mapper;
        private IApplicationRepository repoApplication;
        private IEsmtAppAttachmentDRepository repoEsmtAttachment;
        public GetAttachmentDQueryHandler
        (
           IMapper Mapper,
           IApplicationRepository repoApplication,
           IEsmtAppAttachmentDRepository repoEsmtApplication

        ):base(repoApplication:repoApplication) 
        {
            this.mapper = Mapper;
            this.repoApplication = repoApplication;
            this.repoEsmtAttachment = repoEsmtApplication;
        }
        public async Task<GetAttachmentDQueryViewModel> Handle(GetAttachmentDQuery request, CancellationToken cancellationToken)
        {
            var application = await GetIfApplicationExists(request.ApplicationId);
            var result = new GetAttachmentDQueryViewModel();
            var attacmentDetails = await this.repoEsmtAttachment.GetAttachmentSourcesAsync(request.ApplicationId);
            attacmentDetails = attacmentDetails ?? new List<FarmEsmtAttachmentDSourseEntity>() { new FarmEsmtAttachmentDSourseEntity { ApplicationId= application.Id} };

            result.AttachmentDetails= mapper.Map<IEnumerable<FarmEsmtAttachmentDSourseEntity>, IEnumerable<EsmtAttachmentDViewModel>>(attacmentDetails);
            result.ApplicationId = application.Id;
            return result;
        }
    }
}
