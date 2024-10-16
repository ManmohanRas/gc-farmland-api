namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminClosingDocsCommandValidator : AbstractValidator<SaveEsmtAppAdminClosingDocsCommand>
    {
        public SaveEsmtAppAdminClosingDocsCommandValidator()
        {
            RuleFor(query => query.ApplicationId).GreaterThan(0).WithMessage("Not a Valid Application Id.");
        }
    }
}
