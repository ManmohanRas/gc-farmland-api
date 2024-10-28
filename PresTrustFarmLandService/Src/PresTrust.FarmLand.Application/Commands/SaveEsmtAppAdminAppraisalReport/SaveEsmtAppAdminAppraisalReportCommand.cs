namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminAppraisalReportCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public string AppraiserName1 { get; set; }
        public string AppraiserName2 { get; set; }
        public string LowerAppraiser { get; set; }
        public string HigherAppraiser { get; set; }
        public decimal? PreHLBeforeValue1 { get; set; }
        public decimal? PreHLAfterValue1 { get; set; }
        public decimal? PreHLEsmtValue1 { get; set; }
        public decimal? PreHLBeforeValue2 { get; set; }
        public decimal? PreHLAfterValue2 { get; set; }
        public decimal? PreHLEsmtValue2 { get; set; }
        public decimal? PostHLBeforeValue1 { get; set; }
        public decimal? PostHLAfterValue1 { get; set; }
        public decimal? PostHLEsmtValue1 { get; set; }
        public decimal? PostHLBeforeValue2 { get; set; }
        public decimal? PostHLAfterValue2 { get; set; }
        public decimal? PostHLEsmtValue2 { get; set; }
        public decimal? DiffInEsmtAppraisals { get; set; }
        public decimal? PostHLDifference { get; set; }
        public decimal? DiffInPreandPostHL { get; set; }
        public bool WithInHighlands { get; set; }
        public bool WithInPreservationArea { get; set; }
        public decimal? SADCCertifiedEsmttotal { get; set; }
        public decimal? SADCEsmtBeforePct { get; set; }
        public string AppraisedZoning { get; set; }
        public string ApraisedZoningClass { get; set; }
        public string AppraisalComments { get; set; }
        public DateTime? FreeHolderDate { get; set; }
        public string CurrentZoning { get; set; }
        public decimal? CADBEasement { get; set; }
        public decimal? CADBBefore { get; set; }
        public decimal? CADBEaseBefore { get; set; }
    }
}
