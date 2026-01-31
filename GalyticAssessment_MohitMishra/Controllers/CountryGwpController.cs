using GalyticAssessment_MohitMishra.DataAccess;
using GalyticAssessment_MohitMishra.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GalyticAssessment_MohitMishra.Controllers
{
    [Route("server/api/gwp/avg")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly BusinessGWPService _businessGWPService;
        public CountryGwpController(BusinessGWPService businessGWPService)
        {
            _businessGWPService = businessGWPService;
        }
        // GET: api/<CountryGwp>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryGwp>/5
        [HttpPost]
        public ActionResult GetResult(CountryGWPRequestModel requestModel)
        {
            object httpResponse = null;
            foreach (var record in requestModel.records)
            {
                try
                {
                    DataAccessBase dbObject = new DataAccessBase(_businessGWPService);
                    //Log.Info($"{record.ToString()}");
                    dbObject.GetAvgGWPByLOB(record, out httpResponse);
                    
                }
                catch (Exception ex)
                {
                    httpResponse = "Error occured as part of computation of year wise revenue.";
                }
            }
            var jsonResult = new JsonResult(httpResponse);
            return jsonResult;
        }

        // PUT api/<CountryGwp>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryGwp>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
