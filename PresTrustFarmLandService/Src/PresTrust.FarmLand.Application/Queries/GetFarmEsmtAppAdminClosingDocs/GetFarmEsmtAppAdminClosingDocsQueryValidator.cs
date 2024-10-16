namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQueryValidator : AbstractValidator<GetFarmEsmtAppAdminClosingDocsQuery>
    {
        /// <summary>
        /// create rules for attributes
        /// </summary>
        public GetFarmEsmtAppAdminClosingDocsQueryValidator()
        {
            RuleFor(query => query.ApplicationId)
               .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    }
}
