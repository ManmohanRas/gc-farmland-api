namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries.EmailTemplate;

public class GetEmailTemplateSqlCommand
{
    private readonly string _sqlCommand =
                @"SELECT  [Id]
	                      ,[Title]
                          ,[Subject]
                          ,[TemplateCode]
	                      ,[Description]                         
                   FROM [Farm].[FarmEmailTemplate]
                   WHERE TemplateCode = @p_EmailTemplateCode AND IsActive = 1;";

    public GetEmailTemplateSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
