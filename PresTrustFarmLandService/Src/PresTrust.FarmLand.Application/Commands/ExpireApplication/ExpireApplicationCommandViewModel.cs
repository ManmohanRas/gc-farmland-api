namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandViewModel 
{
    public bool IsSuccess { get; set; } = false;
    public IEnumerable<TermBrokenRuleViewModel> BrokenRules { get; set; } = new List<TermBrokenRuleViewModel>();
}
