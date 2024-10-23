namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminAppraisalReportCommandValidator : AbstractValidator<SaveEsmtAppAdminAppraisalReportCommand>
    {
        public SaveEsmtAppAdminAppraisalReportCommandValidator()
        {
            RuleFor(query => query.ApplicationId)
                    .GreaterThan(0)
                    .WithMessage("Not a valid Application Id.");

        }
    }
}
