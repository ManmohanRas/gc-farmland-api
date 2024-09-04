namespace PresTrust.FarmLand.Application.Commands;

public class ActiveApplicationCommandViewModel
{
    public bool IsSuccess { get; set; } = false;
    public IEnumerable<BrokenRuleViewModel> BrokenRules { get; set; } = new List<BrokenRuleViewModel>();

}
