
namespace PresTrust.FarmLand.Application.Queries;

public class GetAppAdminContactsQueryHandler : IRequestHandler<GetAppAdminContactsQuery, IEnumerable<GetAppAdminContactsQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly ITermAppAdminContactsRepository repoContacts;
    public GetAppAdminContactsQueryHandler(IMapper mapper, ITermAppAdminContactsRepository repoContacts)
    {
        this.mapper = mapper;
        this.repoContacts = repoContacts;
    }
    public async Task<IEnumerable<GetAppAdminContactsQueryViewModel>> Handle(GetAppAdminContactsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TermAppAdminContactsEntity> results = default;

        results = await this.repoContacts.GetAllContactsAsync(request.ApplicationId);

        var contacts = mapper.Map<IEnumerable<TermAppAdminContactsEntity>,IEnumerable<GetAppAdminContactsQueryViewModel>>(results);
        return contacts;
    }
}
