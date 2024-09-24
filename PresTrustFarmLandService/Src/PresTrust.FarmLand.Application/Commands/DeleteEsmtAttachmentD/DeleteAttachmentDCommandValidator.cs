using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Application.Commands.DeleteEsmtAttachmentD
{
    internal class DeleteAttachmentDCommandValidator : AbstractValidator<DeleteAttachmentDCommand>
    {
        public DeleteAttachmentDCommandValidator()
        {
            RuleFor(query => query.ApplicationId)
             .GreaterThan(0)
             .WithMessage("Not a valid ApplicationId");

            RuleFor(query => query.Id)
                .GreaterThan(0)
                .WithMessage("Not a valid CommentId");
        }
    }
}
