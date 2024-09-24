namespace PresTrust.FarmLand.Application.Queries
{
    public class GetAttachmentDQuery: IRequest<GetAttachmentDQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}
