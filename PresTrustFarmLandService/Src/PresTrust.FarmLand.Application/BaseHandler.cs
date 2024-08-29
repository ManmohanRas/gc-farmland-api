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

    public void IsAuthorizedOperation(UserRoleEnum userRole, FarmApplicationEntity application, TermUserPermissionEnum operation, List<FarmFeedbacksEntity> corrections = null)
    {
        var securityMgr = new FarmApplicationSecurityManager(userRole, application.Status, application.ApplicationType);
        permission = securityMgr.Permission;

        VerifyUserAuthorization(operation, userRole);
        VerifyIfOperationIsValidToPerform(operation, application.Status);
    }

    private void VerifyUserAuthorization(TermUserPermissionEnum enumPermission, UserRoleEnum userRole)
    {
        bool authorized = default;

        switch (enumPermission)
        {
            case TermUserPermissionEnum.CREATE_APPLICATION:
                authorized = permission.CanCreateApplication;
                break;
        }
    }

    private void VerifyIfOperationIsValidToPerform(TermUserPermissionEnum enumPermission, TermAppStatusEnum applicationStatus)
    {
        bool isValidOperation = false;

        switch (applicationStatus)
        {
            case TermAppStatusEnum.NONE:
                if (enumPermission == TermUserPermissionEnum.CREATE_APPLICATION)
                    isValidOperation = true;
                break;
            case TermAppStatusEnum.PETITION_DRAFT:
                isValidOperation = DraftStatePermission(enumPermission);
                break;
        }
        }

    private bool DraftStatePermission(TermUserPermissionEnum enumPermission)
    {
        bool flag = false;

        switch (enumPermission)
        {
            case TermUserPermissionEnum.EDIT_LOCATION_SECTION:
            case TermUserPermissionEnum.EDIT_ROLES_SECTION:
            case TermUserPermissionEnum.EDIT_OWNER_DETAILS_SECTION:
            case TermUserPermissionEnum.EDIT_SITE_CHARACTERISTICS_SECTION:
            case TermUserPermissionEnum.EDIT_SIGNATORY_SECTION:
            case TermUserPermissionEnum.EDIT_OTHER_DOCS_SECTION:

            case TermUserPermissionEnum.SUBMIT_APPLICATION:
            case TermUserPermissionEnum.WITHDRAW_APPLICATION:

            case TermUserPermissionEnum.EDIT_COMMENTS:
            case TermUserPermissionEnum.DELETE_COMMENTS:
            case TermUserPermissionEnum.EDIT_FEEDBACK:
            case TermUserPermissionEnum.DELETE_FEEDBACKS:
            case TermUserPermissionEnum.REQUEST_FOR_AN_APPLICATION_CORRECTION:
            case TermUserPermissionEnum.RESPOND_TO_THE_REQUEST_FOR_AN_APPLICATION_CORRECTION:
            case TermUserPermissionEnum.SAVE_DOCUMENT:
            case TermUserPermissionEnum.DELETE_DOCUMENT:
                flag = true;
                break;
            default:
                break;
        }

        return flag;
    }
}
