namespace PresTrust.FarmLand.Application;
public class BaseHandler
{
    private TermAppPermissionEntity permission = default;
    private readonly IApplicationRepository repoApplication;
    public BaseHandler(IApplicationRepository repoApplication = null) 
    {
        this.repoApplication = repoApplication;
    }

    /// <summary>
    /// Get Application for a given Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<FarmApplicationEntity> GetIfApplicationExists(int id)
    {
        var application = await repoApplication.GetApplicationAsync(id);


        if (application == null)
            throw new EntityNotFoundException($"Application (Id: {id}) does not exist or invalid");

        return application;
    }

    public void IsAuthorizedOperation(UserRoleEnum userRole, FarmApplicationEntity application, UserPermissionEnum operation, List<TermFeedbacksEntity> corrections = null)
    {
        var securityMgr = new FarmApplicationSecurityManager(userRole, application.Status, application.ApplicationType);
        permission = securityMgr.Permission;

        VerifyUserAuthorization(operation, userRole);
        VerifyIfOperationIsValidToPerform(operation, application.Status);
    }

    private void VerifyUserAuthorization(UserPermissionEnum enumPermission, UserRoleEnum userRole)
    {
        bool authorized = default;

        switch (enumPermission)
        {
            case UserPermissionEnum.CREATE_APPLICATION:
                authorized = permission.CanCreateApplication;
                break;
        }
    }

    private void VerifyIfOperationIsValidToPerform(UserPermissionEnum enumPermission, ApplicationStatusEnum applicationStatus)
    {
        bool isValidOperation = false;

        switch (applicationStatus)
        {
            case ApplicationStatusEnum.NONE:
                if (enumPermission == UserPermissionEnum.CREATE_APPLICATION)
                    isValidOperation = true;
                break;
            case ApplicationStatusEnum.PETITION_DRAFT:
                isValidOperation = DraftStatePermission(enumPermission);
                break;
        }
        }

    private bool DraftStatePermission(UserPermissionEnum enumPermission)
    {
        bool flag = false;

        switch (enumPermission)
        {
            case UserPermissionEnum.EDIT_LOCATION_SECTION:
            case UserPermissionEnum.EDIT_ROLES_SECTION:
            case UserPermissionEnum.EDIT_OWNER_DETAILS_SECTION:
            case UserPermissionEnum.EDIT_SITE_CHARACTERISTICS_SECTION:
            case UserPermissionEnum.EDIT_SIGNATORY_SECTION:
            case UserPermissionEnum.EDIT_OTHER_DOCS_SECTION:

            case UserPermissionEnum.SUBMIT_APPLICATION:
            case UserPermissionEnum.WITHDRAW_APPLICATION:

            case UserPermissionEnum.EDIT_COMMENTS:
            case UserPermissionEnum.DELETE_COMMENTS:
            case UserPermissionEnum.EDIT_FEEDBACK:
            case UserPermissionEnum.DELETE_FEEDBACKS:
            case UserPermissionEnum.REQUEST_FOR_AN_APPLICATION_CORRECTION:
            case UserPermissionEnum.RESPOND_TO_THE_REQUEST_FOR_AN_APPLICATION_CORRECTION:
            case UserPermissionEnum.SAVE_DOCUMENT:
            case UserPermissionEnum.DELETE_DOCUMENT:
                flag = true;
                break;
            default:
                break;
        }

        return flag;
    }
}
