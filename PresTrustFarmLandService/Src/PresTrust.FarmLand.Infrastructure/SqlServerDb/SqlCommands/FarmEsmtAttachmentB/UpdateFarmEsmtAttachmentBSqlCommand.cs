namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAttachmentBSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE [FARM].[FarmEsmtExceptionsAttachmentB]
            SET              ApplicationId                  =   @p_ApplicationId
                            ,LocationOfException            =   @p_LocationOfException
                            ,Block                          =   @p_Block
                            ,Lot                            =   @p_Lot
                            ,ExceptionSize                  =   @p_ExceptionSize
                            ,ReasonForException             =   @p_ReasonForException
                            ,IsExceptionSoldFromPreserved   =   @p_IsExceptionSoldFromPreserved
                            ,IsRestrictExceptionToResiUnit  =   @p_IsRestrictExceptionToResiUnit
                            ,IsExceptionInNonAgriUse        =   @p_IsExceptionInNonAgriUse
                            ,IsResiExceptionArea            =   @p_IsResiExceptionArea
                            ,IsNonResiExceptionArea         =   @p_IsNonResiExceptionArea
                            ,NonAgriExceptionArea           =   @p_NonAgriExceptionArea
                            ,SingleFamilyResidence          =   @p_SingleFamilyResidence
                            ,ResiHomePermFoundation         =   @p_ResiHomePermFoundation
                            ,ResiDuplex                     =   @p_ResiDuplex
                            ,ResiHomeWithoutFoundation      =   @p_ResiHomeWithoutFoundation
                            ,ResidenceGarage                =   @p_ResidenceGarage
                            ,ResiDormitory                  =   @p_ResiDormitory
                            ,ResiAttachedTo                 =   @p_ResiAttachedTo
                            ,ResiGarriageHouse              =   @p_ResiGarriageHouse
                            ,NonResidentialBarn             =   @p_NonResidentialBarn
                            ,NonResidentialShed             =   @p_NonResidentialShed 
                            ,NonResidentialGarage           =   @p_NonResidentialGarage 
                            ,NonResidentialSilo             =   @p_NonResidentialSilo 
                            ,NonResidentialStable           =   @p_NonResidentialStable
                            ,LastUpdatedBy                  =   @p_LastUpdatedBy  
			                ,LastUpdatedOn                  =   @p_LastUpdatedOn

             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateFarmEsmtAttachmentBSqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
