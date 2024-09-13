namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAttachmentBSqlCommand
{
    private readonly string _sqlCommand =
        @"INSERT INTO [FARM].[FarmEsmtExceptionsAttachmentB]
            (
                             ApplicationId
                            ,LocationOfException
                            ,Block
                            ,Lot
                            ,ExceptionSize
                            ,ReasonForException
                            ,IsExceptionSoldFromPreserved
                            ,IsRestrictExceptionToResiUnit
                            ,IsExceptionInNonAgriUse
                            ,IsResiExceptionArea
                            ,IsNonResiExceptionArea
                            ,NonAgriExceptionArea
                            ,SingleFamilyResidence
                            ,ResiHomePermFoundation
                            ,ResiDuplex
                            ,ResiHomeWithoutFoundation
                            ,ResidenceGarage
                            ,ResiDormitory
                            ,ResiAttachedTo
                            ,ResiGarriageHouse
                            ,NonResidentialBarn
                            ,NonResidentialShed 
                            ,NonResidentialGarage 
                            ,NonResidentialSilo 
                            ,NonResidentialStable
                            ,LastUpdatedBy  
			                ,LastUpdatedOn
             )
                VALUES
                    (
                             @p_ApplicationId
                            ,@p_LocationOfException
                            ,@p_Block
                            ,@p_Lot
                            ,@p_ExceptionSize
                            ,@p_ReasonForException
                            ,@p_IsExceptionSoldFromPreserved
                            ,@p_IsRestrictExceptionToResiUnit
                            ,@p_IsExceptionInNonAgriUse
                            ,@p_IsResiExceptionArea
                            ,@p_IsNonResiExceptionArea
                            ,@p_NonAgriExceptionArea
                            ,@p_SingleFamilyResidence
                            ,@p_ResiHomePermFoundation
                            ,@p_ResiDuplex
                            ,@p_ResiHomeWithoutFoundation
                            ,@p_ResidenceGarage
                            ,@p_ResiDormitory
                            ,@p_ResiAttachedTo
                            ,@p_ResiGarriageHouse
                            ,@p_NonResidentialBarn
                            ,@p_NonResidentialShed 
                            ,@p_NonResidentialGarage 
                            ,@p_NonResidentialSilo 
                            ,@p_NonResidentialStable
                            ,@p_LastUpdatedBy  
			                ,GetDate()
                    );

            SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtAttachmentBSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
