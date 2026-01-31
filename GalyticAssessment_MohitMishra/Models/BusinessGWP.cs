using System;
using System.Formats.Asn1;
using System.Globalization;

namespace GalyticAssessment_MohitMishra.Models
{
    public class BusinessGWP
    {
        public string Country { get; set; }
        public string VariableId { get; set; }
        public string VariableName { get; set; }
        public string LineOfBusiness { get; set; }
        public List<decimal> YearWiseRevenue { get; set; }
    }

    public class BusinessGWPService
    {
        public List<BusinessGWP> BusinessGWPRecords { get; private set; } = new();

        public void LoadData(string filePath)
        {
            try
            {
                BusinessGWPRecords = File.ReadAllLines(filePath)
                    .Skip(1)
                    .Select(line => line.Split(','))
                .Select(fields => new BusinessGWP
                {
                    Country = fields[0],
                    VariableId = fields[1],
                    VariableName = fields[2],
                    LineOfBusiness = fields[3],
                    YearWiseRevenue = fields
                                            .Skip(4)                 // start at column 5 (index 4)
                                            .Take(16)                 // grab columns 5‑20 (indices 4‑19)
                                            .Select(s =>
                                                {
                                                    s = s.Trim();
                                                    return decimal.TryParse(s, out decimal v) ? v : 0;
                                                }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
