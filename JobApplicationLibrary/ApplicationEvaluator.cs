using JobApplicationLibrary.Models;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluator
    {
        private const int minAge = 18;
        //Unit of Work
        public ApplicationResult Evaluate(JobApplication form)
        {
            if (form.Applicant.Age <minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            return ApplicationResult.AutoAccepted;
        }
    }

    public enum ApplicationResult
    {
        AutoRejected,
        TransferredtoHR,
        TransferredtoLead,
        TransfferedtoCTO,
        AutoAccepted

    }
}
