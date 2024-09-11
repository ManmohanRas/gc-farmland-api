namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAttachmentBSqlQuery
{
    private readonly string _sqlCommand =
        @" SELECT            [Id]
                            ,[ApplicationId]
                            ,[LocationOfException]
                            ,[Block]
                            ,[Lot]
                            ,[ExceptionSize]
                            ,[ReasonForException]
                            ,[IsExceptionSoldFromPreserved]
                            ,[IsRestrictExceptionToResiUnit]
                            ,[IsExceptionInNonAgriUse]
                            ,[IsResiExceptionArea]
                            ,[IsNonResiExceptionArea]
                            ,[NonAgriExceptionArea]
                            ,[SingleFamilyResidence]
                            ,[ResiHomePermFoundation]
                            ,[ResiDuplex]
                            ,[ResiHomeWithoutFoundation]
                            ,[ResidenceGarage]
                            ,[ResiDormitory]
                            ,[ResiAttachedTo]
                            ,[ResiGarriageHouse]
                            ,[NonResidentialBarn]
                            ,[NonResidentialShed] 
                            ,[NonResidentialGarage] 
                            ,[NonResidentialSilo] 
                            ,[NonResidentialStable]
                            ,[LastUpdatedBy]  
			                ,[LastUpdatedOn]
                 FROM [FARM].[FarmEsmtExceptionsAttachmentB] WHERE ApplicationId = @p_ApplicationId";

    public GetFarmEsmtAttachmentBSqlQuery()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
