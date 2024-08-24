using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Application.Queries.GetEsmtLiens
{
    public class GetEsmtLiensQuery : IRequest<GetEsmtLiensQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}
