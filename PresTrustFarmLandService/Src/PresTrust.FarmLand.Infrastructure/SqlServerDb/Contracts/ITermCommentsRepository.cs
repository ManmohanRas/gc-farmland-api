namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermCommentsRepository
{

    /// <summary>
    ///  Procedure to fetch all Comments by applicationId.
    /// </summary>
    /// <param name="applicationId"> Application Id.</param>
    /// <returns> Returns Comments.</returns>
    Task<List<TermCommentsEntity>> GetAllCommentsAsync(int applicationId);

    /// <summary>
    /// Save Comment.
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    Task<TermCommentsEntity> SaveAsync(TermCommentsEntity comment);

    /// <summary>
    /// Delete Comment.
    /// </summary>
    /// <returns></returns>
    Task DeleteCommentAsync(TermCommentsEntity comment);

}
