namespace PresTrust.FarmLand.Application.Queries;

/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class GetApplicationSignatoryQuery : IRequest<GetApplicationSignatoryQueryViewModel>
{
    public int ApplicationId { get; set; }

}
