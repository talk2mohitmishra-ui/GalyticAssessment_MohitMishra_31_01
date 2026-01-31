using GalyticAssessment_MohitMishra.Models;
using System.Diagnostics.Metrics;
using System.Text;

namespace GalyticAssessment_MohitMishra.DataAccess
{
    public class DataAccessBase
    {
        private readonly BusinessGWPService _businessGWPService;

        // The DI container automatically provides the Singleton instance here
        public DataAccessBase(BusinessGWPService businessGWPService)
        {
            _businessGWPService = businessGWPService;
        }

        public IEnumerable<BusinessGWP> GetRecordsByCountry(string country)
        {
            return _businessGWPService.BusinessGWPRecords.Where(s => s.Country == country).ToList();
        }

        public void GetAvgGWPByLOB(CountryGWPRequest request, out Object result)
        {
            List<string> sb = new List<string>();
            try
            {
                IEnumerable<BusinessGWP> CountrySpecificRecords = GetRecordsByCountry(request.Country);
                foreach (string lob in request.LOB)
                {
                    IEnumerable<BusinessGWP> LOBSpecificRecords = CountrySpecificRecords.Where(s => s.LineOfBusiness == lob).ToList();
                    if (!LOBSpecificRecords.Any())
                        continue;
                    decimal sum = 0;
                    for (int i = 8; i < 16; i++)
                    {
                        sum += LOBSpecificRecords.First().YearWiseRevenue[i];
                    }
                    decimal average = sum / 8;
                    sb.Add($"{lob} : {average}");
                }
                result = sb;
            }
            catch (Exception)
            {
                result = sb;
            }
        }
    }
}
