


namespace PresTrust.FarmLand.Application.Commands;

public class DeleteTermAppAdminContactsCommandHandler : IRequestHandler<DeleteTermAppAdminContactsCommand, bool>
{

    private readonly IMapper mapper;
    private readonly ITermAppAdminContactsRepository repoContact;

    public DeleteTermAppAdminContactsCommandHandler(
        IMapper mapper,
        ITermAppAdminContactsRepository repoContact)
    {
        this.mapper = mapper;
        this.repoContact = repoContact;
    }
    public async Task<bool> Handle(DeleteTermAppAdminContactsCommand request, CancellationToken cancellationToken)
    {
        var reqContact = mapper.Map<DeleteTermAppAdminContactsCommand, TermAppAdminContactsEntity>(request);
        await repoContact.DeleteContactAsync(reqContact);
        return true;
    }
}
