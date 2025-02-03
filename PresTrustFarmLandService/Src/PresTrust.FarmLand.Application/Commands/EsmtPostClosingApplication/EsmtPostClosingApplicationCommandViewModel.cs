namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommandViewModel
{
    public bool IsSuccess { get; set; } = false;
    public IEnumerable<BrokenRuleViewModel> BrokenRules { get; set; } = new List<BrokenRuleViewModel>();

}
