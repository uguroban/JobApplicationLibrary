namespace JobApplicationLibrary.Models
{
    public class IdentityValidator : IIdentityValidator
    {
        public Applicant Applicant { get; set; }
     

        public bool IsValidIndentity()
        {
            //Adapter
            using (IsValidTCKN.KPSPublicSoapClient client = new IsValidTCKN.KPSPublicSoapClient(IsValidTCKN.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
            {
                return client.TCKimlikNoDogrulaAsync(Convert.ToInt64(Applicant.IdentityNumber), Applicant.FirstName.ToUpper(), Applicant.LastName.ToUpper(), Convert.ToInt32(Applicant.BofYear)).Result.Body.TCKimlikNoDogrulaResult;
            }
        }
    }
}
