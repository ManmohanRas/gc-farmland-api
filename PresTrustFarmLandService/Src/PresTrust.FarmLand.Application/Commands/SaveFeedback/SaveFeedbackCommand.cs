namespace PresTrust.FarmLand.Application.Commands;

public class SaveFeedbackCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int? ApplicationTypeId { get; set; }
    public string Feedback { get; set; }
    public string Section { get; set; }
    public bool RequestForCorrection { get; set; }
}
