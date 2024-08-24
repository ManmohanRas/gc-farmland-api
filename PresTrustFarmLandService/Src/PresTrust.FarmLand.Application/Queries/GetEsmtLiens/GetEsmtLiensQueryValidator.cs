using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Application.Queries.GetEsmtLiens
{
    public class GetEsmtLiensQueryValidator : AbstractValidator<GetEsmtLiensQuery>
    {
        public GetEsmtLiensQueryValidator()
        {
            RuleFor(query => query.ApplicationId)
               .GreaterThan(0).WithMessage("Not a valid Application Id");
        }
    }
}
