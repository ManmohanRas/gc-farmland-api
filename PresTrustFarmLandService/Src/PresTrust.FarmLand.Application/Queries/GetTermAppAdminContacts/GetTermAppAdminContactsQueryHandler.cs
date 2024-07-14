
namespace PresTrust.FarmLand.Application.Queries;

public class GetTermAppAdminContactsQueryHandler : IRequestHandler<GetTermAppAdminContactsQuery, IEnumerable<GetTermAppAdminContactsQueryViewModel>>
{
    private readonly IMapper mapper;
    private readonly ITermAppAdminContactsRepository repoContacts;
    public GetTermAppAdminContactsQueryHandler(IMapper mapper, ITermAppAdminContactsRepository repoContacts)
    {
        this.mapper = mapper;
        this.repoContacts = repoContacts;
    }
    public async Task<IEnumerable<GetTermAppAdminContactsQueryViewModel>> Handle(GetTermAppAdminContactsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TermAppAdminContactsEntity> results = default;

        results = await this.repoContacts.GetAllContactsAsync(request.ApplicationId);

        var contacts = mapper.Map<IEnumerable<TermAppAdminContactsEntity>,IEnumerable<GetTermAppAdminContactsQueryViewModel>>(results);
        return contacts;
    }
}
