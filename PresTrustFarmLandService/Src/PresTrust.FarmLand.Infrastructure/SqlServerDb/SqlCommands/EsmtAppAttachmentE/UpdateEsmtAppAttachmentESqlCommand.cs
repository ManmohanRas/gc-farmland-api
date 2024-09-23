namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateEsmtAppAttachmentESqlCommand
{
    private readonly string _sqlCommand = @"
                                          UPDATE [Farm].[FarmEsmtAppAttachmentE]
                                           SET   ApplicationId                        =  @p_ApplicationId,
                                                 TypeOfDevelopment                    =  @p_TypeOfDevelopment,
                                                 PreliminaryApprovalDate              =  @p_PreliminaryApprovalDate,
                                                 FinalApprovalDate                    =  @p_FinalApprovalDate,
                                                 ScaleofSubdivision                   =  @p_ScaleofSubdivision,
                                                 OtherPertinentInformation            =  @p_OtherPertinentInformation,
                                                 IsOpenEnrollment                     =  @p_IsOpenEnrollment,
                                                 IsPropertyOutlined                   =  @p_IsPropertyOutlined,
                                                 IsAllExpAreasIdentified              =  @p_IsAllExpAreasIdentified,
                                                 IsAllNonAgriEquiUsesDetailed         =  @p_IsAllNonAgriEquiUsesDetailed,
                                                 IsCopyOfDeed                         =  @p_IsCopyOfDeed,
                                                 IsSignOfAllPropOwnersListed          =  @p_IsSignOfAllPropOwnersListed,
                                                 IsFarmLandAssReportCopy              =  @p_IsFarmLandAssReportCopy,
                                                 LastUpdatedBy                        =  @p_LastUpdatedBy,
                                                 LastUpdatedOn                        =  @p_LastUpdatedOn
                                       
                       WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";



 
    public UpdateEsmtAppAttachmentESqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
