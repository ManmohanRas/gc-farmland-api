namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public interface IApplicationFeedbackRepository
{
    /// <summary>
    /// Procedure to fetch application's feedback for a given application status or all
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="correctionStatus"></param>
    /// <returns></returns>
    Task<List<FarmFeedbacksEntity>> GetFeedbacksAsync(int applicationId, string correctionStatus = "");
    // <summary>
    /// Save Feedback.
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns>Returns Feedback.</returns>
    Task<FarmFeedbacksEntity> SaveAsync(FarmFeedbacksEntity feedback);

    /// <summary
    // Mark Feedbacks As Read
    Task MarkFeedbacksAsReadAsync(List<int> FeedbackIds);

    /// <summary
    // Request For Application Correction
    Task RequestForApplicationCorrectionAsync(int applicationId);

    /// <summary>
    /// Response to request for application correction
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="sectionId"></param>
    /// <returns></returns>
    Task ResponseToRequestForApplicationCorrectionAsync(int applicationId, int sectionId);

}
