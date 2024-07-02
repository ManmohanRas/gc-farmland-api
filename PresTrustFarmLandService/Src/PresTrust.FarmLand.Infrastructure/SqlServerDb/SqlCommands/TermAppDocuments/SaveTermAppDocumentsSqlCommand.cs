namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class SaveTermAppDocumentsSqlCommand
{
    private readonly string _sqlCommand =
           @"INSERT INTO [Farm].[FarmApplicationDocument]
                (
			                [FileName]
                           ,[Title]
                           ,[Description]
					       ,[HardCopy]		
					       ,[Approved]		
					       ,[ReviewComment]	
                           ,[DocumentTypeId]
                           ,[ApplicationId]
                           ,[ApplicationTypeId]
                           ,[ShowCommittee])
                     VALUES
                           (@p_FileName
                           ,@p_Title 
                           ,@p_Description
                           ,@p_HardCopy
                           ,@p_Approved
                           ,@p_ReviewComment
                           ,@p_DocumentTypeId 
                           ,@p_ApplicationId
                           ,@p_ApplicationTypeId
                           ,@p_ShowCommittee 
                );

                SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public SaveTermAppDocumentsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
