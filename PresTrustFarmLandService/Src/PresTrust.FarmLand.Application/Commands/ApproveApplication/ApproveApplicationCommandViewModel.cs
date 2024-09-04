namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommandViewModel
{
    public bool IsSuccess { get; set; } = false;
    public IEnumerable<BrokenRuleViewModel> BrokenRules { get; set; } = new List<BrokenRuleViewModel>();
}
