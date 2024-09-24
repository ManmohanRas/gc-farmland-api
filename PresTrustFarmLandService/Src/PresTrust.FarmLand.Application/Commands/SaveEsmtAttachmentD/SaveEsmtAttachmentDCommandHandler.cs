namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAttachmentDCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAttachmentDCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IPresTrustUserContext userContext;
        private readonly SystemParameterConfiguration systemParamOptions;
        private readonly IApplicationRepository repoApplication;
        private IEsmtAppAttachmentDRepository repoEsmtAttachment;
        public SaveEsmtAttachmentDCommandHandler
        (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEsmtAppAttachmentDRepository repoEsmtAttachment
        ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.userContext = userContext;
            this.systemParamOptions = systemParamOptions.Value;
            this.repoApplication = repoApplication;
            this.repoEsmtAttachment = repoEsmtAttachment;
        }

        public async Task<Unit> Handle(SaveEsmtAttachmentDCommand request, CancellationToken cancellationToken)
        {
            //int attachmentId = 0;

            using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
            {
                foreach (var attachment in request.AttachmentDetails)
                {
                    var entity = mapper.Map<SaveEsmtAttachmentDViewModel, FarmEsmtAttachmentDSourseEntity>(attachment);
                    entity.ApplicationId = request.ApplicationId;
                    entity.LastUpdatedBy = userContext.Name;
                    await this.repoEsmtAttachment.SaveAsync(entity);
                 
                }
                scope.Complete();
            }
            return Unit.Value;

        }
    }
}
