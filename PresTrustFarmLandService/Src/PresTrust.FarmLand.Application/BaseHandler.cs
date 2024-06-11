namespace PresTrust.FarmLand.Application
{
    public class BaseHandler
    {
        private TermApplicationPermissionEntity permission = default;
        private readonly IApplicationRepository repoApplication;
        public BaseHandler(IApplicationRepository repoApplication = null) 
        {
            this.repoApplication = repoApplication;
        }
    }
}
