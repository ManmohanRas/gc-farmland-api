
namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtExceptionsCommandHandler : IRequestHandler<SaveFarmEsmtExceptionsCommand , int>
{
    private readonly IMapper mapper;
    private readonly IFarmEsmtExceptionsRepository repoExceptionsRepository;

    public SaveFarmEsmtExceptionsCommandHandler(
        IMapper mapper,
        IFarmEsmtExceptionsRepository repoExceptionsRepository
        )
    {
        this.mapper = mapper;
        this.repoExceptionsRepository = repoExceptionsRepository;

    }

    public async Task<int> Handle( SaveFarmEsmtExceptionsCommand request , CancellationToken cancellationToken )
    {
        var reqExceptions = mapper.Map<SaveFarmEsmtExceptionsCommand, FarmEsmtExceptionsEntity>(request);
        var result = await repoExceptionsRepository.SaveAsync(reqExceptions);

        return result.Id;
    }
}
