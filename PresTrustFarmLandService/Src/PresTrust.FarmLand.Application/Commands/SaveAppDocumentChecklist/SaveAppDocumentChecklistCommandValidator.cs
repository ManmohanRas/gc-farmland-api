namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandValidator : AbstractValidator<SaveAppDocumentChecklistCommand>
{
    /// <summary>
    /// create rules for attributes
    /// </summary>
    public SaveAppDocumentChecklistCommandValidator()
    {
        RuleFor(command => command.ApplicationId)
           .GreaterThan(0).WithMessage("Not a valid Application Id");

        //RuleForEach(command => command.Documents).SetValidator(new DocumentValidator());

        RuleForEach(command => command.Documents).ChildRules(docs =>
        {
            docs.RuleFor(doc => doc.FileName).NotNull().NotEmpty().WithMessage("One or more document's name has not been provided.");
            docs.RuleFor(doc => doc.Title).NotNull().NotEmpty().WithMessage("One or more document's title  is required.");
            docs.RuleFor(doc => doc.DocumentType)
                    .NotNull().NotEmpty()
                    .Must(docType => ValidDocumentType(docType)).WithMessage("One or more document's types are not valid.");
            docs.RuleFor(doc => doc.Section)
                .NotNull().NotEmpty()
                .Must(section => ValidApplicationSection(section)).WithMessage("One or more document's section-names are not valid.");
        });
    }

    /// <summary>
    /// Check if a given document type is valid
    /// </summary>
    /// <param name="docType"></param>
    /// <returns></returns>
    public bool ValidDocumentType(string docType)
    {
        bool result = false;
        Enum.TryParse(value: docType, ignoreCase: true, out ApplicationDocumentTypeEnum enumDocType);

        if (enumDocType > 0)
            result = true;

        return result;
    }

    /// <summary>
    /// Check if a given application section is valid
    /// </summary>
    /// <param name="section"></param>
    /// <returns></returns>
    public bool ValidApplicationSection(string section)
    {
        bool result = false;
        Enum.TryParse(value: section, ignoreCase: true, out TermAppSectionEnum enumSection);

        if (enumSection > 0)
            result = true;

        return result;
    }
}

public class DocumentValidator : AbstractValidator<DocumentsViewModel>
{
    public DocumentValidator()
    {
        RuleFor(query => query.FileName)
           .NotNull().NotEmpty()
           .WithMessage("Document FileName  is required.");

        RuleFor(query => query.Title)
           .NotNull().NotEmpty()
           .WithMessage("Document Title is required.");

        RuleFor(query => query.DocumentType)
         .NotNull().NotEmpty()
         .Must(x => ValidDocumentType(x)).WithMessage("Not a valid document type.");
    }

    /// <summary>
    /// Check if a given document type is valid
    /// </summary>
    /// <param name="docType"></param>
    /// <returns></returns>
    public bool ValidDocumentType(string docType)
    {
        bool result = false;
        Enum.TryParse(value: docType, ignoreCase: true, out ApplicationDocumentTypeEnum enumDocType);

        if (enumDocType > 0)
            result = true;

        return result;
    }
}
