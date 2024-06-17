namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class GetRoleSqlCommand
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
                FROM		[Flood].[FloodApplicationUser]
                WHERE		ApplicationId = @p_ApplicationId;";
    public GetRoleSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
