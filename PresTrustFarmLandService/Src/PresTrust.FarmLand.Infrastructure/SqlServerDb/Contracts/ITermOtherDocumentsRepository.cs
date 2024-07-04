namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermOtherDocumentsRepository
{
    /// <summary>
    ///  Procedure to fetch Document by Application Id.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="sectionId"></param>
    /// <returns></returns>
    Task<List<TermOtherDocumentsEntity>> GetTermDocumentsAsync(int applicationId, int sectionId);

    /// <summary>
    /// Procedure to save uploaded application document details
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    Task<TermOtherDocumentsEntity> SaveTermDocumentDetailsAsync(TermOtherDocumentsEntity doc);

    /// <summary>
    /// Procedure to delete application document
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteApplicationDocumentAsync(int id);

    /// <summary>
    /// Procedure to update application document checklist
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    Task<TermOtherDocumentsEntity> SaveTermDocumentChecklistAsync(TermOtherDocumentsEntity doc);

    /// <summary>
    /// Procedure to get Property document checklist
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<List<TermOtherDocumentsEntity>> GetTermDocumentChecklistAsync(int applicationId);
}
