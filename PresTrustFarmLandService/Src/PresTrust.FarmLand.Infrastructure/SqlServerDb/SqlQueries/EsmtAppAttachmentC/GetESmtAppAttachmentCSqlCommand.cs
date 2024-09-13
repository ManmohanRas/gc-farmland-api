namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetESmtAppAttachmentCSqlCommand
{


    private readonly string  _sqlCommand= @"
                                         SELECT         [Id]
                                                       ,[ApplicationId]
                                                       ,[IsExceptionAreaPreserved]
                                                       ,[IsNonAgriPremisesPreserved]
                                                       ,[DescNonAgriUses]
                                                       ,[NonAgriAreaUtilization]
                                                       ,[NonAgriLease]
                                                       ,[NonAgriUseAccessParcel]
                                                       ,[LastUpdatedBy]
                                                       ,[LastUpdatedOn]
                              FROM 
                                   [Farm].[FarmEsmtAttachmentC] WHERE ApplicationId = @p_ApplicationId;";


    

    public GetESmtAppAttachmentCSqlCommand(){}
    public override string ToString()
    {
        return _sqlCommand;
    }

}
