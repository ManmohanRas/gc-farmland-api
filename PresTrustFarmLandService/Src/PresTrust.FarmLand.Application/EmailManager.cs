namespace PresTrust.FarmLand.Application;

public interface IEmailManager
{
    Task SendMail(string subject, string htmlBody, int applicationId, string applicationName, string? emailTemplateCode = default, int agencyId = default, OwnerDetailsEntity? owner = default, FarmBlockLotEntity? blockLot = default, string municapality = default , DateTime? MonitoringDateStart = default , DateTime? MonitoringDateEnd = default);

}

public class EmailManager : IEmailManager
{

    private readonly IMapper mapper;
    private readonly IEmailApiConnect emailApiConnect;
    private readonly IFarmRolesRepository repoApplicationRole;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IPresTrustUserContext userContext;
    private readonly IIdentityApiConnect identityApiConnect;
    private readonly ITermAppAdminContactsRepository repoContact;

    public EmailManager(
        IMapper mapper,
        IEmailApiConnect emailApiConnect,
        IFarmRolesRepository repoApplicationRole,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IPresTrustUserContext userContext,
        IIdentityApiConnect identityApiConnect,
        ITermAppAdminContactsRepository repoContact
    )
    {
        this.emailApiConnect = emailApiConnect;
        this.repoApplicationRole = repoApplicationRole;
        this.systemParamOptions = systemParamOptions.Value;
        this.userContext = userContext;
        this.identityApiConnect = identityApiConnect;
        this.repoContact = repoContact;
    }


    private async Task<Tuple<List<string>, List<string>>> GetPrimaryContact(int applicationId, int agencyId)
    {
        List<string> primaryContactNames = new List<string>();
        List<string> primaryContactEmails = new List<string>();

        var endPoint = $"{systemParamOptions.IdentityApiSubDomain}/UserAdmin/users/pres-trust/farm/{agencyId}";
        var agencyUsers = await identityApiConnect.GetDataAsync<List<IdentityApiUser>>(endPoint);

        var primaryContacts = await repoApplicationRole.GetRolesAsync(applicationId);
        var primaryAgencyUsers = agencyUsers.Where(o => primaryContacts.Select(x => x.Email?.Trim()).Contains(o.Email?.Trim()));

        if (primaryContacts.Count() > 0)
        {
            //primaryContacts.Select(i => string.Concat(i.FirstName, ' ', i.LastName)).ToList();
            primaryContactEmails = primaryContacts.Select(i => i.Email).ToList();
            if (primaryAgencyUsers.Count() > 0)
            //{
            //    primaryContactNames = primaryAgencyUsers.Where(x => x.IsEnabled).Select(o => string.Format("{0} {1}", o.FirstName, o.LastName)).ToList();
            //}
            //else
            //{
                primaryContactNames = primaryContacts.Where(x => x.IsPrimaryContact == true).Select(o => o.UserName).ToList();
            //}

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
    public async Task SendMail(string subject, string htmlBody, int applicationId,  string applicationName, string? emailTemplateCode = default, int agencyId = default, OwnerDetailsEntity? owner = default, FarmBlockLotEntity? blockLot = default, string municapality = default, DateTime? MonitoringDateStart = default, DateTime? MonitoringDateEnd = default)
    {
        var primaryContact = await GetPrimaryContact(applicationId, agencyId);
        List<string> alternateContactEmails = new List<string>();
        string contactEmails = default;
        string contactName = default;

        var contacts = await repoContact.GetAllContactsAsync(applicationId);
        contactEmails = contacts.Where(o => o.SelectContact).Select(x => x.Email).FirstOrDefault();
        contactName = contacts.Select(x => x.ContactName).FirstOrDefault();

        var toEmails = String.Empty;
        var cc = String.Empty;

        DateTime today = DateTime.Today;
        DateTime nextMonth = today.AddMonths(1);
        DateTime fifthNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 5);

        htmlBody = htmlBody.Replace("{{ProgramAdmin}}", systemParamOptions.ProgramAdminName);
        htmlBody = htmlBody.Replace("{{ProgramAdminEmail}}", systemParamOptions.ProgramAdminEmail ?? "");
        htmlBody = htmlBody.Replace("{{AgencyAdmin}}", userContext.Name ?? "");
        htmlBody = htmlBody.Replace("{{PrimaryContactName}}", string.Join(",", primaryContact.Item1));
        htmlBody = htmlBody.Replace("{{FarmName}}", applicationName ?? "");
        htmlBody = htmlBody.Replace("{{SADCContact}}", contactName  ?? "");
        htmlBody = htmlBody.Replace("{{NextMeetingDate}}", fifthNextMonth.ToString("dddd, MMMM dd, yyyy"));
        htmlBody = htmlBody.Replace("{{ProjectName}}", applicationName ?? "");
        htmlBody = htmlBody.Replace("{{TodaysDate}}", DateTime.Now.ToString("MMMM dd, yyyy") ?? "");
        htmlBody = htmlBody.Replace("{{ApplicationName}}", applicationName ?? "");
        htmlBody = htmlBody.Replace("{{MonitoringDateStart}}", MonitoringDateStart?.ToString("dddd, MMMM dd, yyyy"));
        htmlBody = htmlBody.Replace("{{MonitoringDateStart}}", MonitoringDateEnd?.ToString("dddd, MMMM dd, yyyy"));

        if (owner!=null)
        {
            htmlBody = htmlBody.Replace("{{OwnerFirst}}", owner.FirstName ?? "");
            htmlBody = htmlBody.Replace("{{OwnerLast}}", owner.LastName ?? "");
        }
        else
        {
            htmlBody = htmlBody.Replace("{{OwnerFirst}}", "");
            htmlBody = htmlBody.Replace("{{OwnerLast}}",  "");
        }

        if (blockLot!=null)
        {
            htmlBody = htmlBody.Replace("{{DeedBook}}", blockLot.DeedBook ?? "");
            htmlBody = htmlBody.Replace("{{DeedPage}}", blockLot.DeedPage ?? "");
            htmlBody = htmlBody.Replace("{{Block}}", blockLot.Block ?? "");
            htmlBody = htmlBody.Replace("{{Lot}}", blockLot.Lot ?? "");
            htmlBody = htmlBody.Replace("{{Municipality}}", blockLot.Municipality ?? "");
            htmlBody = htmlBody.Replace("{{Acres}}", blockLot.Acres.ToString() ?? "");


            subject = subject.Replace("{{Block}}", blockLot.Block ?? "");
            subject = subject.Replace("{{Lot}}", blockLot.Lot ?? "");
            subject = subject.Replace("{{Municipality}}", blockLot.Municipality ?? "");
        }
        else
        {
            htmlBody = htmlBody.Replace("{{DeedBook}}",  "");
            htmlBody = htmlBody.Replace("{{DeedPage}}",  "");
            htmlBody = htmlBody.Replace("{{Block}}", "");
            htmlBody = htmlBody.Replace("{{Lot}}","");
            htmlBody = htmlBody.Replace("{{Municipality}}",  "");
            htmlBody = htmlBody.Replace("{{Acres}}", "");


            subject = subject.Replace("{{Block}}","");
            subject = subject.Replace("{{Lot}}", "");
            subject = subject.Replace("{{Municipality}}",  "");
        }
       
        subject = subject.Replace("{{FarmName}}", applicationName ?? "");

   

        if (primaryContact.Item2.Count() > 0)
        {
            toEmails = string.Join(",", primaryContact.Item2);
        }
        else
        {
            toEmails = systemParamOptions.ProgramAdminEmail ?? String.Empty;
        }

        if (toEmails != systemParamOptions.ProgramAdminEmail)
        {
            cc = string.Join(",", systemParamOptions.ProgramAdminEmail);
        }
        else
        {
            cc = null;
        }

        var senderName = systemParamOptions.IsDevelopment == false ? userContext.Name : systemParamOptions.TestEmailFromUserName;
        var senderEmail = systemParamOptions.IsDevelopment == false ? userContext.Email : "mcgis@co.morris.nj.us";

        await this.Send(subject: subject, toEmails: toEmails, senderName: senderName, senderEmail: senderEmail, htmlBody: htmlBody, cc: cc);
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
