namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmSadcResidenceQueryHandler : BaseHandler, IRequestHandler<GetFarmSadcResidenceQuery, GetFarmSadcResidenceQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IFarmSadcResidenceRepository repoSadcResidence;
    private readonly IEsmtAppStructureRepository repoStructure;
    private readonly IEsmtAppAttachmentCRepository repoAttachmentC;
    private IEsmtLiensReposioty repoliens;


    public GetFarmSadcResidenceQueryHandler
       (
           IMapper mapper,
           IFarmSadcResidenceRepository repoSadcResidence,
           IEsmtAppStructureRepository repoStructure,
           IEsmtAppAttachmentCRepository repoAttachmentC,
           IEsmtLiensReposioty repoliens,
           IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoSadcResidence = repoSadcResidence;
        this.repoStructure = repoStructure;
        this.repoAttachmentC = repoAttachmentC;
        this.repoApplication = repoApplication;
        this.repoliens = repoliens;
    }

    public async Task<GetFarmSadcResidenceQueryViewModel> Handle(GetFarmSadcResidenceQuery request, CancellationToken cancellationToken)
    {
        //get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqSadcResidence = await repoSadcResidence.GetSadcResidenceAsync(request.ApplicationId);

        //Structures
        var structures = await repoStructure.GetEsmtStructureEntityAsync(request.ApplicationId);
        structures = structures ?? new EsmtStructureAppEntity();

        //AttachmentC
        var attachmentCResult = await repoAttachmentC.GetEsmtAppAttachmentCAsync(request.ApplicationId);
        var attachmentC = attachmentCResult?.FirstOrDefault() != null
        ? mapper.Map<EsmtAppAttachmentCEntity>(attachmentCResult.FirstOrDefault())
        : new EsmtAppAttachmentCEntity();

        // Lines Esmt 
        var linesEsmt = await repoliens.GetLiensAsync(request.ApplicationId);
        linesEsmt = linesEsmt ?? new EsmtLiensEntity();

        var sadcResidenceDetails = mapper.Map<FarmSadcResidenceEntity, GetFarmSadcResidenceQueryViewModel>(reqSadcResidence);

        sadcResidenceDetails.IsResipreserved = structures.IsResipreserved;
        sadcResidenceDetails.StdSingleFamilyResidence = structures.StdSingleFamilyResidence;
        sadcResidenceDetails.MfWithHomePermFoundation = structures.MfWithHomePermFoundation;
        sadcResidenceDetails.Duplex = structures.Duplex;
        sadcResidenceDetails.MfWithOutHomePermFoundation = structures.MfWithOutHomePermFoundation;
        sadcResidenceDetails.ResiGarage = structures.ResiGarage;
        sadcResidenceDetails.Dormitory = structures.Dormitory;
        sadcResidenceDetails.ApartmentAttachedTo = structures.ApartmentAttachedTo;
        sadcResidenceDetails.CarriageHouseOrCabin = structures.CarriageHouseOrCabin;
        sadcResidenceDetails.IsNonResiStructure = structures.IsNonResiStructure;
        sadcResidenceDetails.Barn = structures.Barn;
        sadcResidenceDetails.Shed = structures.Shed;
        sadcResidenceDetails.NonResiGarage = structures.NonResiGarage;
        sadcResidenceDetails.Silo = structures.Silo;
        sadcResidenceDetails.Stable = structures.Stable;
        sadcResidenceDetails.NonResiOther = structures.NonResiOther;
        sadcResidenceDetails.IsNonAgriPremisesPreserved = attachmentC.IsNonAgriPremisesPreserved;
        sadcResidenceDetails.DescNonAgriUses = attachmentC.DescNonAgriUses;
        sadcResidenceDetails.PremisePreserved = linesEsmt.PremisePreserved;
        sadcResidenceDetails.PowerLines = linesEsmt.PowerLines;
        sadcResidenceDetails.WaterLines = linesEsmt.WaterLines;
        sadcResidenceDetails.Sewer = linesEsmt.Sewer;
        sadcResidenceDetails.Bridge = linesEsmt.Bridge;
        sadcResidenceDetails.FloodRightWay = linesEsmt.FloodRightWay;
        sadcResidenceDetails.TelephoneLines = linesEsmt.TelephoneLines;
        sadcResidenceDetails.GasLines = linesEsmt.GasLines;
        sadcResidenceDetails.Other = linesEsmt.Other;
        sadcResidenceDetails.SolarWindBiomass = linesEsmt.SolarWindBiomass;
        sadcResidenceDetails.BiomassDescribe = linesEsmt.BiomassDescribe;

        return sadcResidenceDetails;

    }
}
