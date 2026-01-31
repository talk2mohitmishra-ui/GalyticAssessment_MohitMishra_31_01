namespace GalyticAssessment_MohitMishra.Models
{
    public class CountryGWPRequest
    {
        public string Country { get; set; }
        public List<string> LOB { get; set; }
    }

    public class CountryGWPRequestModel
    {
        public List<CountryGWPRequest> records { get; set; }
    }
}
