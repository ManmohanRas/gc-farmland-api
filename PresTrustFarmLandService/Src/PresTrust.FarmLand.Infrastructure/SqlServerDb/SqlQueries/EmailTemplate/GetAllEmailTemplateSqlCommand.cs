namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetAllEmailTemplateSqlCommand
{
    private readonly string _sqlCommand =
               @"SELECT  [Id]
                          ,[TemplateCode]
	                      ,[Title]
                          ,[Subject]
	                      ,[Description]                       
                   FROM [Farm].[FarmEmailTemplate]
                   WHERE  IsActive = 1;";

    public GetAllEmailTemplateSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
