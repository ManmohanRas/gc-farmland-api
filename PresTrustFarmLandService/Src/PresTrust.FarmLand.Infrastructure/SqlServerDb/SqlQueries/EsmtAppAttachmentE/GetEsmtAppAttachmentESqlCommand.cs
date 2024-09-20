namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetEsmtAppAttachmentESqlCommand
{
    private readonly string _sqlCommand = @"
          SELECT       Id
                      ,ApplicationId               
                      ,TypeOfDevelopment           
                      ,PreliminaryApprovalDate     
                      ,FinalApprovalDate           
                      ,ScaleofSubdivision          
                      ,OtherPertinentInformation   
                      ,IsOpenEnrollment            
                      ,IsPropertyOutlined          
                      ,IsAllExpAreasIdentified     
                      ,IsAllNonAgriEquiUsesDetailed
                      ,IsCopyOfDeed                
                      ,IsSignOfAllPropOwnersListed
                      ,IsFarmLandAssReportCopy     
                      ,LastUpdatedBy               
                      ,LastUpdatedOn                             
               FROM
                     [Farm].[FarmEsmtAppAttachmentE]    WHERE ApplicationId =@P_ApplicationId;";
  public GetEsmtAppAttachmentESqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
