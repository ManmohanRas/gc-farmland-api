namespace PresTrust.FarmLand.Application;

public interface IEmailManager
{
    Task SendMail(string subject, string htmlBody, int applicationId, string applicationName, string ownerName = default, string site = default, string fundingYear = default, DateTime fundingRoundClosingDate = default,
    DateTime? dateAnnualReportDue = default, string structure = null, decimal finalTotalProjectCost = default, DateTime? consultantQnADuedate = default, DateTime? recommendedDate = default, DateTime? commissionerMeetingDate = default,
    int agencyId = default, string agencyName = default, decimal finalGrantAmount = default, decimal grantAmount = default, DateTime? applicationDeadline = default, DateTime? grantExpirationDate = default, int? totalPayments = default, 
    int? balanceOfGrant = default, string? emailTemplateCode = default);
}

public class EmailManager : IEmailManager
{

    private readonly IMapper mapper;
    private readonly IEmailApiConnect emailApiConnect;
    private readonly IFarmRolesRepository repoApplicationRole;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IPresTrustUserContext userContext;
    private readonly IIdentityApiConnect identityApiConnect;

    public EmailManager(
        IMapper mapper,
        IEmailApiConnect emailApiConnect,
        IFarmRolesRepository repoApplicationRole,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IPresTrustUserContext userContext,
        IIdentityApiConnect identityApiConnect
    )
    {
        this.emailApiConnect = emailApiConnect;
        this.repoApplicationRole = repoApplicationRole;
        this.systemParamOptions = systemParamOptions.Value;
        this.userContext = userContext;
        this.identityApiConnect = identityApiConnect;
    }


    private async Task<Tuple<List<string>, List<string>>> GetPrimaryContact(int applicationId, int agencyId)
    {
        List<string> primaryContactNames = new List<string>();
        List<string> primaryContactEmails = new List<string>();

        var endPoint = $"{systemParamOptions.IdentityApiSubDomain}/UserAdmin/users/pres-trust/farm/{agencyId}";
        var agencyUsers = await identityApiConnect.GetDataAsync<List<IdentityApiUser>>(endPoint);

        var primaryContacts = await repoApplicationRole.GetRolesAsync(applicationId);

        if (primaryContacts.Count() > 0)
        {
            var primaryAgencyUsers = agencyUsers.Where(o => primaryContacts.Select(x => x.Email?.Trim()).Contains(o.Email?.Trim()));
            //primaryContacts.Select(i => string.Concat(i.FirstName, ' ', i.LastName)).ToList();
            primaryContactEmails = primaryContacts.Select(i => i.Email).ToList();
            if (primaryAgencyUsers.Count() > 0)
            {
                primaryContactNames = primaryAgencyUsers.Select(o => string.Format("{0} {1}", o.FirstName, o.LastName)).ToList();
            }
            else
            {
                primaryContactNames = primaryContacts.Select(o => string.Format("{0} {1}", o.FirstName, o.LastName)).ToList();
            }

        }
        else
        {
            var agencyAdmin = agencyUsers.Where(au => au.UserRole == IdentityClaimTypes.FARM_AGENCY_ADMIN).FirstOrDefault();
            if (agencyAdmin != null)
            {
                primaryContactNames.Add(string.Concat(agencyAdmin.FirstName, ' ', agencyAdmin.LastName));
                primaryContactEmails.Add(agencyAdmin.Email);
            }
        }
        return new Tuple<List<string>, List<string>>(primaryContactNames, primaryContactEmails);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="agencyId"></param>
    /// <param name="subject"></param>
    /// <param name="htmlBody"></param>
    /// <param name="flagTestEmail"></param>
    /// <returns></returns>
    public async Task SendMail(string subject, string htmlBody, int applicationId, string applicationName, string ownerName, string site, string fundingYear = default, DateTime fundingRoundClosingDate = default, DateTime? dateAnnualReportDue = default, string structure = null, decimal finalTotalProjectCost = default, DateTime? consultantQnADuedate = default, DateTime? recommendedDate = default, DateTime? commissionerMeetingDate = default, int agencyId = default, string agencyName = default, decimal finalGrantAmount = default, decimal grantAmount = default, DateTime? applicationDeadline = default, DateTime? grantExpirationDate = default, int? totalPayments = default, int? balanceOfGrant = default, string? emailTemplateCode = default)
    {
        var primaryContact = await GetPrimaryContact(applicationId, agencyId);


        var endPoint = $"{systemParamOptions.IdentityApiSubDomain}/UserAdmin/users/pres-trust/farm";
        var countyUsers = await identityApiConnect.GetDataAsync<List<IdentityApiUser>>(endPoint);
        var programAdminName = countyUsers.Where(o => o.UserRole == "farm_program_admin").Select(o => string.Concat(o.FirstName, ' ', o.LastName)).FirstOrDefault();
        var programAdminEmail = countyUsers.Where(o => o.UserRole == "farm_program_admin").Select(o => o.Email).FirstOrDefault();
        var toEmails = String.Empty;

        htmlBody = htmlBody.Replace("{{ProgramAdmin}}", userContext.IsExternalUser ? string.Format("{0} {1}", systemParamOptions.ProgramAdminName.Split('-')[0], systemParamOptions.ProgramAdminName.Split('-')[1]) : programAdminName ?? "");
        htmlBody = htmlBody.Replace("{{ProgramAdminEmail}}", userContext.Email ?? "");
        htmlBody = htmlBody.Replace("{{AgencyAdmin}}", userContext.Name ?? "");
       


        subject = subject.Replace("{{ApplicationName}}", applicationName ?? "");
        subject = subject.Replace("{{PropertyName}}", site ?? "");
      
       toEmails = systemParamOptions.IsDevelopment == false ? string.Join(",", primaryContact.Item2) : systemParamOptions.TestEmailIds;        

        var senderName = systemParamOptions.IsDevelopment == false ? userContext.Name : systemParamOptions.TestEmailFromUserName;
        var senderEmail = systemParamOptions.IsDevelopment == false ? userContext.Email : "mcgis@co.morris.nj.us";

        await this.Send(subject: subject, toEmails: toEmails, senderName: senderName, senderEmail: senderEmail, htmlBody: htmlBody);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="toEmails"></param>
    /// <param name="senderName"></param>
    /// <param name="senderEmail"></param>
    /// <param name="htmlBody"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <returns></returns>
    private async Task Send(string subject, string toEmails, string senderName, string senderEmail, string htmlBody, string cc = null, string bcc = null)
    {
        var retry = Policy
            .Handle<Exception>()
            .WaitAndRetry(systemParamOptions.PollyRetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(systemParamOptions.PollyRetryIntervalInSeconds, retryAttempt)));

        var postUserJson = new JsonContent(new EmailRequest()
        {
            Subject = subject,
            To = toEmails,
            SenderName = senderName,
            SenderEmail = senderEmail,
            CC = cc,
            BCC = bcc,
            HtmlBody = htmlBody,
            Attachments = null
        });

        try
        {
            await retry.Execute(async () =>
            {
                // call external api - EmailApi
                var result = await this.emailApiConnect.PostDataAsync<EmailResponse, JsonContent>($"{systemParamOptions.EmailApiSubDomain}/Email", postUserJson);
            });
        }
        catch
        {
            throw new Exception("Error occured while sending the email.");
        }
    }
}
