namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateEsmtAppAttachmentESqlCommand
{

    private readonly string _SqlCommand = @"

       INSERT INTO [Farm].[FarmEsmtAppAttachmentE] 
          (  ApplicationId,
             TypeOfDevelopment,
             PreliminaryApprovalDate,
             FinalApprovalDate,
             ScaleofSubdivision,
             OtherPertinentInformation,
             IsOpenEnrollment,
             IsPropertyOutlined,
             IsAllExpAreasIdentified,
             IsAllNonAgriEquiUsesDetailed,
             IsCopyOfDeed,
             IsSignOfAllPropOwnersListed,
             IsFarmLandAssReportCopy,
             LastUpdatedBy,
             LastUpdatedOn
          )
          VALUES(
                 @p_ApplicationId,
                 @p_TypeOfDevelopment,
                 @p_PreliminaryApprovalDate,
                 @p_FinalApprovalDate,
                 @p_ScaleofSubdivision,
                 @p_OtherPertinentInformation,
                 @p_IsOpenEnrollment,
                 @p_IsPropertyOutlined,
                 @p_IsAllExpAreasIdentified,
                 @p_IsAllNonAgriEquiUsesDetailed,
                 @p_IsCopyOfDeed,
                 @p_IsSignOfAllPropOwnersListed,
                 @p_IsFarmLandAssReportCopy,
                 @p_LastUpdatedBy,
                 GETDATE()
             ); 
               SELECT CAST(SCOPE_IDENTITY() AS INT)";



    public CreateEsmtAppAttachmentESqlCommand() { }

    public override string ToString()
    {
        return _SqlCommand;
    }
}
