namespace PresTrust.FarmLand.Application.Queries;

/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class GetTermAppSignatoryQuery : IRequest<GetTermAppSignatoryQueryViewModel>
{
    public int ApplicationId { get; set; }

}
