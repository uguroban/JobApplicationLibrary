using JobApplicationLibrary.Models;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluator
    {
        private const int minAge = 18;
        private const int autoAcceptedYearsofExperience = 5;
        private List<string> techStackList = new() {"C#","RabbitMQ","MicroServices","Visual Studio" };
        private readonly IIdentityValidator identityValidator;

        public ApplicationEvaluator(IIdentityValidator identityValidator)
        {
            this.identityValidator = identityValidator;
        }
        //Unit of Work
        public ApplicationResult Evaluate(JobApplication form)
        {
            if (form.Applicant.Age <minAge)
            {
                return ApplicationResult.AutoRejected;
            }

            var validIdentity = identityValidator.IsValidIndentity();
            if (!validIdentity) { 
                return ApplicationResult.TransferredtoHR; 
            }


            var sr = GetTechStackRate(form.TechStackList);
            if (sr<25)
            {
                return ApplicationResult.AutoRejected;
            }
            if (sr>75 && form.YearsofExperience >= autoAcceptedYearsofExperience)
            {
                return ApplicationResult.AutoAccepted;
            }
            return ApplicationResult.AutoAccepted;
        }

        private int GetTechStackRate(List<string> userTechStacks)
        {
            var matchCount = userTechStacks.Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase)).Count();
            return (int)(double)(matchCount/techStackList.Count())*100;
            
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
