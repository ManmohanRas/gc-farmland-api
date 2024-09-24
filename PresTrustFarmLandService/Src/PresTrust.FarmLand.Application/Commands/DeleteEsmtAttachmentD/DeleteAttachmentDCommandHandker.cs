using AutoMapper;

namespace PresTrust.FarmLand.Application.Commands
{
    public class DeleteAttachmentDCommandHandker: BaseHandler, IRequestHandler<DeleteAttachmentDCommand , bool>
    {
        private readonly IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private readonly IEsmtAppAttachmentDRepository repoAttachmentD;
        public DeleteAttachmentDCommandHandker
           ( IMapper mapper,
            IApplicationRepository repoApplication,
            IEsmtAppAttachmentDRepository repoAttachmentD
            ) : base(repoApplication)
        {
            this.mapper = mapper;
            this.repoApplication = repoApplication;
            this.repoAttachmentD = repoAttachmentD;
        }


        public async Task<bool> Handle(DeleteAttachmentDCommand request, CancellationToken cancellationToken)
        {
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var activity = mapper.Map<DeleteAttachmentDCommand, FarmEsmtAttachmentDSourseEntity>(request);

            await repoAttachmentD.DeleteAsync(activity);

            return true;
        }
    }
}
