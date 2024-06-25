namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetRolesSqlCommand
{
    private readonly string _sqlCommand =
       @"      SELECT		 Id
			                ,ApplicationId
			                ,UserId
			                ,Email
			                ,UserName
                            ,FirstName
                            ,LastName
			                ,Title
			                ,PhoneNumber
			                ,IsPrimaryContact
                            ,IsAlternateContact
                FROM		[Farm].[FarmApplicationUser]
                WHERE		ApplicationId = @p_ApplicationId;";
    public GetRolesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
