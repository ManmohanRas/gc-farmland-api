namespace PresTrust.FarmLand.Application.Queries
{
    public class GetEsmtAppAdminAppraisalReportQueryValidator : AbstractValidator<GetEsmtAppAdminAppraisalReportQuery>
    {
        /// <summary>
        /// create rules for attributes
        /// </summary>
        public GetEsmtAppAdminAppraisalReportQueryValidator()
        {
            RuleFor(query => query.ApplicationId)
               .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    }
}
