namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminExceptionRDSOCommandHandler : IRequestHandler<SaveEsmtAppAdminExceptionRDSOCommand, int>
{
    private readonly IMapper mapper;
    private readonly IEsmtAppAdminExceptionRDSORepository repoExceptionRDSORepository;
    private readonly IPresTrustUserContext userContext;


    public SaveEsmtAppAdminExceptionRDSOCommandHandler(
       IMapper mapper,
       IEsmtAppAdminExceptionRDSORepository repoExceptionRDSORepository,
       IPresTrustUserContext userContext
       )
    {
        this.mapper = mapper;
        this.repoExceptionRDSORepository = repoExceptionRDSORepository;
        this.userContext = userContext;

    }

    public async Task<int> Handle(SaveEsmtAppAdminExceptionRDSOCommand request, CancellationToken cancellationToken)
    {
        var reqExceptionRDSODetails = mapper.Map<SaveEsmtAppAdminExceptionRDSOCommand, EsmtAppAdminExceptionRDSOEntity>(request);
        reqExceptionRDSODetails.LastUpdatedBy = userContext.Email;
        var result = await repoExceptionRDSORepository.SaveExceptionRDSOdetailsAsync(reqExceptionRDSODetails);

        return result.Id;
    }

}
