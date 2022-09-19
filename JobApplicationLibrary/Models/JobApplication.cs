namespace JobApplicationLibrary.Models
{
    public class JobApplication
    {
        public Applicant Applicant { get; set; }

        public int YearsofExperience { get; set; }

        public List<string> TechStackList { get; set; }
    }
}
