namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IApplicationCommentRepository
{

    /// <summary>
    ///  Procedure to fetch all Comments by applicationId.
    /// </summary>
    /// <param name="applicationId"> Application Id.</param>
    /// <returns> Returns Comments.</returns>
    Task<List<FarmCommentsEntity>> GetAllCommentsAsync(int applicationId);

    /// <summary>
    /// Save Comment.
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    Task<FarmCommentsEntity> SaveAsync(FarmCommentsEntity comment);

    /// <summary>
    /// Delete Comment.
    /// </summary>
    /// <returns></returns>
    Task DeleteCommentAsync(FarmCommentsEntity comment);

}
