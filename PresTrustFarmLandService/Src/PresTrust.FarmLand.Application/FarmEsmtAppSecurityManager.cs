namespace PresTrust.FarmLand.Application;
public class FarmEsmtAppSecurityManager
{
    private UserRoleEnum userRole = default;
    private EsmtAppStatusEnum applicationStatus = default;
    private EsmtAppPermissionEntity esmtPermission = default;
    private List<NavigationItemEntity> navigationItems = default;
    private List<NavigationItemEntity> adminNavigationItems = default;
    private List<NavigationItemEntity> postApprovedNavigationItems = default;
    private List<NavigationItemEntity> sadcNavigationItems = default;
    private NavigationItemEntity defaultNavigationItem = default;
    private bool IsSADC = default;
    private List<FarmFeedbacksEntity> corrections = new List<FarmFeedbacksEntity>();
    public FarmEsmtAppSecurityManager(UserRoleEnum userRole, EsmtAppStatusEnum applicationStatus, List<FarmFeedbacksEntity> corrections = null, bool IsSADC = false)
    {
        this.userRole = userRole;
        this.applicationStatus = applicationStatus;
        this.IsSADC = IsSADC;
        this.corrections = corrections ?? new List<FarmFeedbacksEntity>();

        ConfigurePermissions();
    }

    public EsmtAppPermissionEntity EsmtPermission { get { return esmtPermission; } }
    public List<NavigationItemEntity> NavigationItems { get => navigationItems; }
    public List<NavigationItemEntity> AdminNavigationItems { get => adminNavigationItems; }
    public List<NavigationItemEntity> PostApprovedNavigationItems { get => postApprovedNavigationItems; }
    public List<NavigationItemEntity> SADCNavigationItems { get => sadcNavigationItems; }
    public NavigationItemEntity DefaultNavigationItem { get => defaultNavigationItem; }

    public void ConfigurePermissions()
    {
        esmtPermission = new EsmtAppPermissionEntity();
        navigationItems = new List<NavigationItemEntity>();
        adminNavigationItems = new List<NavigationItemEntity>();
        sadcNavigationItems = new List<NavigationItemEntity>();

        if (userRole == UserRoleEnum.AGENCY_ADMIN || userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN || userRole == UserRoleEnum.PROGRAM_EDITOR || userRole == UserRoleEnum.AGENCY_EDITOR)
        {
            esmtPermission.CanCreateApplication = true;
        }

        switch (applicationStatus)
        {
            case EsmtAppStatusEnum.NONE:
                break;
            case EsmtAppStatusEnum.DRAFT_APPLICATION:
                this.DeriveDraftStatePermissions();
                break;
            case EsmtAppStatusEnum.APPLICATION_SUBMITTED:
                this.DeriveSubmittedStatePermissions();
                break;
            case EsmtAppStatusEnum.IN_REVIEW:
                this.DeriveInReviewStatePermissions();
                break;
            case EsmtAppStatusEnum.PENDING:
                this.DerivePendingStatePermissions();
                break;
            case EsmtAppStatusEnum.ACTIVE:
                this.DeriveActiveStatePermissions();
                break;
            case EsmtAppStatusEnum.CLOSING:
                this.DeriveClosingStatePermissions();
                break;
            case EsmtAppStatusEnum.REJECTED:
            case EsmtAppStatusEnum.WITHDRAWN:
                this.DeriveRejectedStatePermissions();
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
                    esmtPermission.CanSubmitApplication = true;
                }

                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    esmtPermission.CanSubmitApplication = true;
                }
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
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
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();

                if (userRole == UserRoleEnum.AGENCY_SIGNATORY)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory();

                OtherDocuments();


                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();
                

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveSubmittedStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:

                esmtPermission.CanReviewApplication = true;
                esmtPermission.CanRequestForAnApplicationCorrection = true;
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanEditFeedback = true;
                esmtPermission.CanDeleteFeedback = true;
                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanApproveApplication = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanViewOtherDocsSection = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanViewFeedback = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:

                esmtPermission.CanViewFeedback = true;
                //esmtPermission.CanReviewApplication = true;

                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    esmtPermission.CanViewComments = true;
                }

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }

      }

    private void DeriveInReviewStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:

                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    esmtPermission.CanRejectApplication = true;
                    esmtPermission.CanSwitchSADC = true;
                }

                esmtPermission.CanRequestForAnApplicationCorrection = true;
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanEditFeedback = true;
                esmtPermission.CanDeleteFeedback = true;
                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanApproveApplication = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (IsSADC)
                {
                    SADCFarmInformation(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCResiOnEsmtArea(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCFarmHistory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityI(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityII(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanViewOtherDocsSection = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanViewFeedback = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:

                esmtPermission.CanViewFeedback = true;

                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    esmtPermission.CanViewComments = true;
                }

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }

    }

    private void DerivePendingStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:


                esmtPermission.CanRequestForAnApplicationCorrection = true;
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanEditFeedback = true;
                esmtPermission.CanDeleteFeedback = true;
                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanActivateApplication = true;
                esmtPermission.CanRejectApplication = true;
                esmtPermission.CanWithdrawApplication = true;


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (userRole == UserRoleEnum.PROGRAM_ADMIN && IsSADC)
                {
                    SADCFarmInformation(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCResiOnEsmtArea(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCFarmHistory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityI(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityII(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                esmtPermission.CanViewOtherDocsSection = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanViewFeedback = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.VIEW);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:

                esmtPermission.CanViewFeedback = true;

                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    esmtPermission.CanViewComments = true;
                }

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
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

                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;

                if (userRole == UserRoleEnum.PROGRAM_ADMIN || userRole == UserRoleEnum.SYSTEM_ADMIN)
                {
                    esmtPermission.CanRequestForAnApplicationCorrection = true;
                    esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                    esmtPermission.CanEditFeedback = true;
                    esmtPermission.CanDeleteFeedback = true;
                    esmtPermission.CanWithdrawApplication = true;
                }

                Location();

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (IsSADC)
                {
                    SADCFarmInformation(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCResiOnEsmtArea(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCFarmHistory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityI(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityII(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                }
                esmtPermission.CanViewOtherDocsSection = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanViewFeedback = true;

                Location();

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:

                esmtPermission.CanSwitchSADC = false;
                if (userRole != UserRoleEnum.AGENCY_READONLY)
                {
                    esmtPermission.CanViewFeedback = true;
                }
                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    SADCFarmInformation();
                    SADCResiOnEsmtArea();
                    SADCFarmHistory();
                    SADCAppEligibilityI();
                    SADCAppEligibilityII();
                    esmtPermission.CanViewComments = true;
                }

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }

    }

    private void DeriveClosingStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:

                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;

                if (userRole == UserRoleEnum.PROGRAM_ADMIN || userRole == UserRoleEnum.SYSTEM_ADMIN)
                {
                    esmtPermission.CanRequestForAnApplicationCorrection = true;
                    esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                    esmtPermission.CanEditFeedback = true;
                    esmtPermission.CanDeleteFeedback = true;
                    esmtPermission.CanWithdrawApplication = true;
                }

                Location();

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                if (IsSADC)
                {
                    SADCFarmInformation(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCResiOnEsmtArea(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCFarmHistory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityI(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                    SADCAppEligibilityII(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };

                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                }
                esmtPermission.CanViewOtherDocsSection = true;
                esmtPermission.CanSaveDocument = true;
                esmtPermission.CanDeleteDocument = true;
                esmtPermission.CanViewFeedback = true;

                Location();

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:

                esmtPermission.CanSwitchSADC = false;
                if (userRole != UserRoleEnum.AGENCY_READONLY)
                {
                    esmtPermission.CanViewFeedback = true;
                }
                if (userRole == UserRoleEnum.PROGRAM_COMMITTEE || userRole == UserRoleEnum.PROGRAM_READONLY)
                {
                    SADCFarmInformation();
                    SADCResiOnEsmtArea();
                    SADCFarmHistory();
                    SADCAppEligibilityI();
                    SADCAppEligibilityII();
                    esmtPermission.CanViewComments = true;
                }

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }

    }

    private void DeriveRejectedStatePermissions()
    {
        FarmFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
                esmtPermission.CanViewFeedback = true;
                esmtPermission.CanViewComments = true;
                esmtPermission.CanEditComments = true;
                esmtPermission.CanEditFeedback = true;
                esmtPermission.CanDeleteComments = true;
                esmtPermission.CanRequestForAnApplicationCorrection = true;
                esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminCostDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminAppraisalReport(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminOfferCosts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminStructures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminExceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminSADC(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminClosingDocs(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;

            
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.PROGRAM_EDITOR:
            esmtPermission.CanViewComments = true;
            esmtPermission.CanViewFeedback = true;

                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();
                AdminDocumentChecklist();
                AdminCostDetails();
                AdminAppraisalReport();
                AdminOfferCosts();
                AdminStructures();
                AdminExceptions();
                AdminSADC();
                AdminClosingDocs();
                AdminDetails();
                AdminContacts();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
            case UserRoleEnum.AGENCY_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
                if (userRole == UserRoleEnum.AGENCY_ADMIN || userRole == UserRoleEnum.AGENCY_EDITOR)
                {
                    esmtPermission.CanRespondToTheRequestForAnApplicationCorrection = true;
                }

                if (userRole != UserRoleEnum.AGENCY_READONLY)
                {
                    esmtPermission.CanViewFeedback = true;
                    esmtPermission.CanSwitchSADC = false;
                }
                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LOCATION).FirstOrDefault();
                if (correction == null)
                {
                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                        SortOrder = 1
                    };
                    Location();
                }
                else
                {
                    Location(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                    this.defaultNavigationItem = new NavigationItemEntity()
                    {
                        Title = EsmtAppNavigationItemTitles.LOCATION,
                        RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                        SortOrder = 1
                    };
                }

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OWNER_DETAILS).FirstOrDefault();
                if (correction == null)
                {
                    OwnerDetails();
                }
                else
                    OwnerDetails(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.ROLES).FirstOrDefault();
                if (correction == null)
                {
                    Roles();
                }
                else
                    Roles(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXCEPTIONS).FirstOrDefault();
                if (correction == null)
                {
                    Exceptions();
                }
                else
                    Exceptions(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES).FirstOrDefault();
                if (correction == null)
                {
                    Structures();
                }
                else
                    Structures(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.LIENS_EASEMENT_ROW).FirstOrDefault();
                if (correction == null)
                {
                    Liens();
                }
                else
                    Liens(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EXIS_NON_AGRI_USES).FirstOrDefault();
                if (correction == null)
                {
                    ExistingUses();
                }
                else
                    ExistingUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION).FirstOrDefault();
                if (correction == null)
                {
                    AgriculturalUseProduction();
                }
                else
                    AgriculturalUseProduction(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.EQUINE_USES).FirstOrDefault();
                if (correction == null)
                {
                    EquineUses();
                }
                else
                    EquineUses(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.SIGNATORY).FirstOrDefault();
                if (correction == null)
                {
                    Signatory();
                }
                else
                    Signatory(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                correction = this.corrections.Where(c => c.Section == EsmtAppSectionEnum.OTHER_DOCUMENTS).FirstOrDefault();
                if (correction == null)
                {
                    OtherDocuments();
                }
                else
                    OtherDocuments(correction: true, enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                break;

            default:
                Location();
                OwnerDetails();
                Roles();
                Exceptions();
                Structures();
                Liens();
                ExistingUses();
                AgriculturalUseProduction();
                EquineUses();
                Signatory();
                OtherDocuments();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
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
                esmtPermission.CanViewLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LOCATION, RouterLink = EsmtAppRouterLinks.LOCATION_VIEW, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LOCATION, RouterLink = EsmtAppRouterLinks.LOCATION_EDIT, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OWNER_DETAILS, RouterLink = EsmtAppRouterLinks.OWNER_DETAILS_VIEW, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OWNER_DETAILS, RouterLink = EsmtAppRouterLinks.OWNER_DETAILS_EDIT, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ROLES, RouterLink = EsmtAppRouterLinks.ROLES_VIEW, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ROLES, RouterLink = EsmtAppRouterLinks.ROLES_EDIT, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Exceptions(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXCEPTIONS, RouterLink = EsmtAppRouterLinks.EXCEPTIONS_VIEW, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXCEPTIONS, RouterLink = EsmtAppRouterLinks.EXCEPTIONS_EDIT, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Structures(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.RESI_NON_RESI_STRUCTURES, RouterLink = EsmtAppRouterLinks.RESI_NON_RESI_STRUCTURES_VIEW, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.RESI_NON_RESI_STRUCTURES, RouterLink = EsmtAppRouterLinks.RESI_NON_RESI_STRUCTURES_EDIT, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Liens(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LIENS_EASEMENT_ROW, RouterLink = EsmtAppRouterLinks.LIENS_EASEMENT_ROW_VIEW, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LIENS_EASEMENT_ROW, RouterLink = EsmtAppRouterLinks.LIENS_EASEMENT_ROW_EDIT, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void ExistingUses(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXIS_NON_AGRI_USES, RouterLink = EsmtAppRouterLinks.EXIS_NON_AGRI_USES_VIEW, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXIS_NON_AGRI_USES, RouterLink = EsmtAppRouterLinks.EXIS_NON_AGRI_USES_EDIT, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AgriculturalUseProduction(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.AGRICULTURAL_USE_PRODUCTION, RouterLink = EsmtAppRouterLinks.AGRICULTURAL_USE_PRODUCTION_VIEW, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.AGRICULTURAL_USE_PRODUCTION, RouterLink = EsmtAppRouterLinks.AGRICULTURAL_USE_PRODUCTION_EDIT, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void EquineUses(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EQUINE_USES, RouterLink = EsmtAppRouterLinks.EQUINE_USES_VIEW, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EQUINE_USES, RouterLink = EsmtAppRouterLinks.EQUINE_USES_EDIT, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SIGNATORY, RouterLink = EsmtAppRouterLinks.SIGNATORY_VIEW, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SIGNATORY, RouterLink = EsmtAppRouterLinks.SIGNATORY_EDIT, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = EsmtAppRouterLinks.OTHER_DOCUMENTS_VIEW, SortOrder = 11, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = EsmtAppRouterLinks.OTHER_DOCUMENTS_EDIT, SortOrder = 11, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    //Admin Actions

    private void AdminDocumentChecklist(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_DOCUMENT_CHECK_LIST, RouterLink = EsmtAppRouterLinks.ADMIN_DOCUMENT_CHECK_LIST_VIEW, SortOrder = 12, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_DOCUMENT_CHECK_LIST, RouterLink = EsmtAppRouterLinks.ADMIN_DOCUMENT_CHECK_LIST_EDIT, SortOrder = 12, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminCostDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminCostDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_COST_DETAILS, RouterLink = EsmtAppRouterLinks.ADMIN_COST_DETAILS_VIEW, SortOrder = 13, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminCostDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_COST_DETAILS, RouterLink = EsmtAppRouterLinks.ADMIN_COST_DETAILS_EDIT, SortOrder = 13, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminAppraisalReport(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminAppraisalReportSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_APPRAISAL_REPORTS, RouterLink = EsmtAppRouterLinks.ADMIN_APPRAISAL_REPORTS_VIEW, SortOrder = 14, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminAppraisalReportSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_APPRAISAL_REPORTS, RouterLink = EsmtAppRouterLinks.ADMIN_APPRAISAL_REPORTS_EDIT, SortOrder = 14, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminOfferCosts(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminOfferCostsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_OFFER_COSTS, RouterLink = EsmtAppRouterLinks.ADMIN_OFFER_COSTS_VIEW, SortOrder = 15, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminOfferCostsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_OFFER_COSTS, RouterLink = EsmtAppRouterLinks.ADMIN_OFFER_COSTS_EDIT, SortOrder = 15, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminStructures(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminStructuresSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_STRUCTURES, RouterLink = EsmtAppRouterLinks.ADMIN_STRUCTURES_VIEW, SortOrder = 16, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminStructuresSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_STRUCTURES, RouterLink = EsmtAppRouterLinks.ADMIN_STRUCTURES_EDIT, SortOrder = 16, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }


    private void AdminExceptions(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminExceptionsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_EXCEPTIONS, RouterLink = EsmtAppRouterLinks.ADMIN_EXCEPTIONS_VIEW, SortOrder = 17, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminExceptionsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_EXCEPTIONS, RouterLink = EsmtAppRouterLinks.ADMIN_EXCEPTIONS_EDIT, SortOrder = 17, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminSADC(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminSADCSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_SADC, RouterLink = EsmtAppRouterLinks.ADMIN_SADC_VIEW, SortOrder = 18, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminSADCSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_SADC, RouterLink = EsmtAppRouterLinks.ADMIN_SADC_EDIT, SortOrder = 18, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminClosingDocs(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewAdminClosingDocsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_CLOSING_DOCS, RouterLink = EsmtAppRouterLinks.ADMIN_CLOSING_DOCS_VIEW, SortOrder = 19, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminClosingDocsection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_CLOSING_DOCS, RouterLink = EsmtAppRouterLinks.ADMIN_CLOSING_DOCS_EDIT, SortOrder = 19, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewAdminDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = EsmtAppRouterLinks.ADMIN_DETAILS_VIEW, SortOrder = 20, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = EsmtAppRouterLinks.ADMIN_DETAILS_EDIT, SortOrder = 20, Icon = (correction == true ? "report_problem" : "") });
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
                esmtPermission.CanViewAdminContactsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = EsmtAppRouterLinks.ADMIN_CONTACTS_VIEW, SortOrder = 21, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditAdminContactsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = EsmtAppRouterLinks.ADMIN_CONTACTS_EDIT, SortOrder = 21, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }


    //SADC tabs
    private void SADCFarmInformation(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewSADCFarmInformationSection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_FARM_INFORMATION, RouterLink = EsmtAppRouterLinks.SADC_FARM_INFORMATION_VIEW, SortOrder = 22, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSADCFarmInformationSection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_FARM_INFORMATION, RouterLink = EsmtAppRouterLinks.SADC_FARM_INFORMATION_EDIT, SortOrder = 22, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SADCResiOnEsmtArea(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewSADCResionEsmtAreaSection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_RESI_ON_ESMT_AREA, RouterLink = EsmtAppRouterLinks.SADC_RESI_ON_ESMT_AREA_VIEW, SortOrder = 23, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSADCResionEsmtAreaSection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_RESI_ON_ESMT_AREA, RouterLink = EsmtAppRouterLinks.SADC_RESI_ON_ESMT_AREA_EDIT, SortOrder = 23, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SADCFarmHistory(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewSADCFarmHistorySection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_FARM_HISTORY, RouterLink = EsmtAppRouterLinks.SADC_FARM_HISTORY_VIEW, SortOrder = 24, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSADCFarmHistorySection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_FARM_HISTORY, RouterLink = EsmtAppRouterLinks.SADC_FARM_HISTORY_EDIT, SortOrder = 24, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SADCAppEligibilityI(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewSADCAppEligibilityISection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_APP_ELIGIBILITY_I, RouterLink = EsmtAppRouterLinks.SADC_APP_ELIGIBILITY_I_VIEW, SortOrder = 25, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSADCAppEligibilityISection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_APP_ELIGIBILITY_I, RouterLink = EsmtAppRouterLinks.SADC_APP_ELIGIBILITY_I_EDIT, SortOrder = 25, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SADCAppEligibilityII(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                esmtPermission.CanViewSADCAppEligibilityIISection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_APP_ELIGIBILITY_II, RouterLink = EsmtAppRouterLinks.SADC_APP_ELIGIBILITY_II_VIEW, SortOrder = 26, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                esmtPermission.CanEditSADCAppEligibilityIISection = true;
                sadcNavigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SADC_APP_ELIGIBILITY_II, RouterLink = EsmtAppRouterLinks.SADC_APP_ELIGIBILITY_II_EDIT, SortOrder = 26, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

}

