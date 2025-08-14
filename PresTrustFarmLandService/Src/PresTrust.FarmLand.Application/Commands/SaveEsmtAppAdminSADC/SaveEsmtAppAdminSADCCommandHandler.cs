namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminSADCCommandHandler : IRequestHandler<SaveEsmtAppAdminSADCCommand, int>
{
    private readonly IMapper mapper;
    private readonly IEsmtAppAdminSADCRepository repoSADCRepository;
    private readonly IPresTrustUserContext userContext;


    public SaveEsmtAppAdminSADCCommandHandler(
       IMapper mapper,
       IEsmtAppAdminSADCRepository repoSADCRepository,
       IPresTrustUserContext userContext
       )
    {
        this.mapper = mapper;
        this.repoSADCRepository = repoSADCRepository;
        this.userContext = userContext;

    }


    public async Task<int> Handle(SaveEsmtAppAdminSADCCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var reqSADCDetails = mapper.Map<SaveEsmtAppAdminSADCCommand, EsmtAppAdminSADCEntity>(request);
        reqSADCDetails.LastUpdatedBy = userContext.Email;
        var result = await repoSADCRepository.SaveSADCdetailsAsync(reqSADCDetails);

        return result.Id;
    }
}
