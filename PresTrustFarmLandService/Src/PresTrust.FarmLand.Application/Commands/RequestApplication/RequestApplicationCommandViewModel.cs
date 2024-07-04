using PresTrust.FarmLand.Domain;

namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommandViewModel
{
    public bool IsSuccess { get; set; } = false;
    public IEnumerable<TermBrokenRuleViewModel> BrokenRules { get; set; } = new List<TermBrokenRuleViewModel>();
}
