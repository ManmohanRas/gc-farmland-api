namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppExistUsesCommand:IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsSubdivisionApproval { get; set; }
    public string InfoAboutPremises { get; set; }

}
