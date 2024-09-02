

namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppAdminContactsCommandHandler : BaseHandler, IRequestHandler<SaveAppAdminContactsCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermAppAdminContactsRepository repoContacts;

    public SaveAppAdminContactsCommandHandler
        (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IApplicationRepository repoApplication,
        ITermAppAdminContactsRepository repoContacts

        ) : base(repoApplication)
    {
      this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.repoContacts = repoContacts;
         
    }

    public async Task<bool> Handle(SaveAppAdminContactsCommand request, CancellationToken cancellationToken)
    {
        var application = await GetIfApplicationExists(request.ApplicationId);

        foreach (var contact in request.Contacts)
        {
            var reqContact = mapper.Map<SaveContactsModel, TermAppAdminContactsEntity>(contact);
            reqContact.ApplicationId = application.Id;
            reqContact.LastUpdatedBy = userContext.Email;

            await this.repoContacts.SaveAsync(reqContact);
        }

        return true;
    }
}
