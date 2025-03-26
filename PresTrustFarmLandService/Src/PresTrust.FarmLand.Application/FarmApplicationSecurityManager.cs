namespace PresTrust.FarmLand.Application;

public class FarmApplicationSecurityManager
{
    private UserRoleEnum userRole = default;
    private TermAppStatusEnum applicationStatus = default;
    private ApplicationTypeEnum applicationTypeEnum = default;
    private TermAppPermissionEntity permission = default;
    private List<NavigationItemEntity> navigationItems = default;
    private List<NavigationItemEntity> adminNavigationItems = default;
    private List<NavigationItemEntity> postApprovedNavigationItems = default;
    private NavigationItemEntity defaultNavigationItem = default;
    private List<FarmFeedbacksEntity> corrections = new List<FarmFeedbacksEntity>();

    public FarmApplicationSecurityManager(UserRoleEnum userRole, TermAppStatusEnum applicationStatus, ApplicationTypeEnum applicationType, List<FarmFeedbacksEntity> corrections = null)
    {
        this.userRole = userRole;
        this.applicationStatus = applicationStatus;
        this.applicationTypeEnum = applicationType;
        this.corrections = corrections ?? new List<FarmFeedbacksEntity>();

        this.userRole = userRole;
        
       ConfigurePermissions();
       
    }


    public TermAppPermissionEntity Permission { get { return permission; } }
    public List<NavigationItemEntity> NavigationItems { get => navigationItems; }
    public List<NavigationItemEntity> AdminNavigationItems { get => adminNavigationItems; }
    public List<NavigationItemEntity> PostApprovedNavigationItems { get => postApprovedNavigationItems; }
    public NavigationItemEntity DefaultNavigationItem { get => defaultNavigationItem; }

    //need to re work on it
    //Term Program
    public void ConfigurePermissions()
    {


        permission = new TermAppPermissionEntity();
        navigationItems = new List<NavigationItemEntity>();
        adminNavigationItems = new List<NavigationItemEntity>();
        postApprovedNavigationItems = new List<NavigationItemEntity>();

        if (userRole == UserRoleEnum.AGENCY_ADMIN || userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN || userRole == UserRoleEnum.PROGRAM_EDITOR || userRole == UserRoleEnum.AGENCY_EDITOR)
        {
            permission.CanCreateApplication = true;
        }

        switch (applicationStatus)
        {
            case TermAppStatusEnum.NONE:
                break;
            case TermAppStatusEnum.PETITION_DRAFT:
                DeriveDraftStatePermissions();
                break;
            case TermAppStatusEnum.PETITION_REQUEST:
                DeriveRequestedStatePermissions();
                break;
            case TermAppStatusEnum.PETITION_APPROVED:
                DeriveApprovedStatePermissions();
                break;
            case TermAppStatusEnum.AGREEMENT_APPROVED:
                DeriveAgreementApprovedStatePermissions();
                break;
            case TermAppStatusEnum.ACTIVE:
                DeriveActiveStatePermissions();
                break;
            case TermAppStatusEnum.WITHDRAWN:
                DeriveWithdrawnStatePermissions();
                break;
            case TermAppStatusEnum.REJECTED:
                DeriveWithdrawnStatePermissions();
                break;
            case TermAppStatusEnum.EXPIRED:
                DeriveWithdrawnStatePermissions();
                break;
        }

    }

    private void DeriveDraftStatePermissions()
    {
        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanSubmitApplication = true;
                    permission.CanWithdrawApplication = true;
                }

                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    permission.CanSubmitApplication = true;
                }
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

            
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
            case UserRoleEnum.AGENCY_READONLY:

                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                if (userRole == UserRoleEnum.AGENCY_SIGNATORY)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }else
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveRequestedStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanReviewApplication = true;
                permission.CanRequestForAnApplicationCorrection = true;
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanEditFeedback = true;
                permission.CanDeleteFeedback = true;
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanApproveApplication = true;

                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanWithdrawApplication = true;
                }
                //Location
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if(correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }else
                OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if(correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                } else
                Roles(correction: true,enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if(correction == null)
                {
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                } else
                SiteCharacteristics(correction: true,enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if(correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                } else
                OtherDocuments(correction: true,enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                {
                    Signatory(correction: true,enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                if (userRole == UserRoleEnum.PROGRAM_EDITOR)
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
          
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanViewOtherDocsSection = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanViewFeedback = true;


                //LOCATION
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }
                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                
             break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
                
                permission.CanViewFeedback = true;

                if(userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    permission.CanViewComments = true;
                }
                Location();
                //Owner Details
                OwnerDetails();
                //Roles
                Roles();
                //Site Characteristics
                SiteCharacteristics();
                //Other Documents
                OtherDocuments();
                //Signatory
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
            default:
                // Location
                Location();
                //Owner Details
                OwnerDetails();
                //Roles
                Roles();
                //Site Characteristics
                SiteCharacteristics();
                //Other Documents
                OtherDocuments();
                //Signatory
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveApprovedStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanReviewApplication = true;
                permission.CanRequestForAnApplicationCorrection = true;
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanEditFeedback = true;
                permission.CanDeleteFeedback = true;
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanRejectApplication = true;
                permission.CanWithdrawApplication = true;
                permission.CanAgreementApproveApplication = true;
                permission.CanSwitchSADC = true;
                
                //LOCATION
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (userRole == UserRoleEnum.PROGRAM_EDITOR)
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                   // permission.CanSubmitApplication = true;
                    permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanViewFeedback = true;

                //LOCATION
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);

                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }

                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                break;
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
            case UserRoleEnum.AGENCY_READONLY:

                permission.CanSwitchSADC = false;
                permission.CanViewFeedback = true;
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveAgreementApprovedStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanReviewApplication = true;
                permission.CanRequestForAnApplicationCorrection = true;
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanEditFeedback = true;
                permission.CanDeleteFeedback = true;
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanActivateApplication = true;

                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanWithdrawApplication = true;
                }



                //LOCATION
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (userRole == UserRoleEnum.PROGRAM_EDITOR)
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanViewFeedback = true;

                //LOCATION
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = TermAppNavigationItemTitles.LOCATION,
                        RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };

                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
            case UserRoleEnum.AGENCY_READONLY:
                permission.CanSwitchSADC = false;
                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    permission.CanViewComments = true;
                }
                permission.CanViewFeedback = true;
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveActiveStatePermissions()
    {
        FarmFeedbacksEntity correction = default;
        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanRequestForAnApplicationCorrection = true;
                permission.CanEditFeedback = true;
                permission.CanDeleteFeedback = true;
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanWithdrawApplication = true;
                }
                //LOCATION
                //correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                //if (correction == null)
                //    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //else
                //    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Location();
                //Owner Details
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //SiteCharacteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Document Checklist
                if (userRole == UserRoleEnum.PROGRAM_EDITOR)
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                else
                    AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Details
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Release of Funds
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Contacts
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
           
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanViewFeedback = true;
                // Location
                Location();
                //correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.LOCATION).FirstOrDefault();
                //if (correction == null)
                //{
                //    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);

                //    this.defaultNavigationItem = new NavigationItemEntity()
                //    {
                //        Title = TermAppNavigationItemTitles.LOCATION,
                //        RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                //        SortOrder = 1
                //    };
                //}
                //else
                //{
                //    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                //    this.defaultNavigationItem = new NavigationItemEntity()
                //    {
                //        Title = TermAppNavigationItemTitles.LOCATION,
                //        RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                //        SortOrder = 1
                //    };
                //}
                //OwnerDetails
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                    OwnerDetails();
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Roles
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                    Roles();
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Site Characteristics
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SITE_CHARACTERISTICS).FirstOrDefault();
                if (correction == null)
                    SiteCharacteristics();
                else
                    SiteCharacteristics(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Other Documents
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                    OtherDocuments();
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Signatory
                correction = this.corrections.Where(c => c.Section == TermAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                    
                }
                else
                {
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                   
                }
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
            case UserRoleEnum.AGENCY_READONLY:

                permission.CanSwitchSADC = false;
                if (userRole != UserRoleEnum.AGENCY_READONLY) { 
                    permission.CanViewFeedback = true;
                }
                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    permission.CanViewComments = true;
                }
                // Location
                Location();
                //Owner Details
                OwnerDetails();
                //Roles
                Roles();
                //Site Characteristics
                SiteCharacteristics();
                //Other Documents
                OtherDocuments();
                //Signatory
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };

                break;
            default:
                // Location
                Location();
                //Owner Details
                OwnerDetails();
                //Roles
                Roles();
                //Site Characteristics
                SiteCharacteristics();
                //Other Documents
                OtherDocuments();
                //Signatory
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveWithdrawnStatePermissions()
    {
        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            //case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanEditFeedback =  true;
                permission.CanDeleteFeedback =  true;


                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Document Checklist
                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Details
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Deed Details
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                //Admin Contacts
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.PROGRAM_EDITOR:
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanViewFeedback = true;
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                //Admin Document Checklist
                AdminDocumentChecklist();
                //Admin Details
                AdminDetails();
                //Admin Deed Details
                AdminDeedDetails();
                //Admin Contacts
                AdminContacts();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
                if (userRole != UserRoleEnum.AGENCY_READONLY)
                {
                    permission.CanViewFeedback = true;
                    permission.CanSwitchSADC = false;
                }
                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    permission.CanViewComments = true;
                    permission.CanSwitchSADC = false;
                    permission.CanViewFeedback = true;
                }
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    private void Location(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.LOCATION, RouterLink = TermApplicationRouterLinks.LOCATION_VIEW, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.LOCATION, RouterLink = TermApplicationRouterLinks.LOCATION_EDIT, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void OwnerDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OWNER_DETAILS, RouterLink = TermApplicationRouterLinks.OWNER_DETAILS_VIEW, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OWNER_DETAILS, RouterLink = TermApplicationRouterLinks.OWNER_DETAILS_EDIT, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Roles(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ROLES, RouterLink = TermApplicationRouterLinks.ROLES_VIEW, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ROLES, RouterLink = TermApplicationRouterLinks.ROLES_EDIT, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SiteCharacteristics(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewSiteCharacteristicsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SITE_CHARACTERISTICS, RouterLink = TermApplicationRouterLinks.SITE_CHARACTERISTICS_VIEW, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditSiteCharacteristicsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SITE_CHARACTERISTICS, RouterLink = TermApplicationRouterLinks.SITE_CHARACTERISTICS_EDIT, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Signatory(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SIGNATORY, RouterLink = TermApplicationRouterLinks.SIGNATORY_VIEW, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SIGNATORY, RouterLink = TermApplicationRouterLinks.SIGNATORY_EDIT, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void OtherDocuments(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_VIEW, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }


    private void AdminDocumentChecklist(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DOCUMENT_CHECKLIST, RouterLink = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_VIEW, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DOCUMENT_CHECKLIST, RouterLink = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_EDIT, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DETAILS_VIEW, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DETAILS_EDIT, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminDeedDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DEED_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DEED_DETAILS_VIEW, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DEED_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DEED_DETAILS_EDIT, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminContacts(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminContactsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = TermApplicationRouterLinks.ADMIN_CONTACTS_VIEW, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminContactsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = TermApplicationRouterLinks.ADMIN_CONTACTS_EDIT, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }


}
