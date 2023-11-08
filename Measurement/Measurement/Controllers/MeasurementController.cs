using Microsoft.AspNetCore.Mvc;
using Measurement.Models;
using System.Data.SqlClient;
using Measurement.Services;
namespace Measurement.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public MeasurementController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ConnectionString");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Measurements()
        {
            var measurements = MeasurementService.GetMeasurementParameters(connectionString);
            return View(measurements);
        }

        public IActionResult RemoveMeasurement()
        {
            var removeElement = MeasurementService.RemoveMeasurementParameter(connectionString);
            return View("RemoveMeasurement", removeElement);
        }

        public IActionResult UpdateDatabaseEntry()
        {
            var updateElement = MeasurementService.UpdateElementFromDB(connectionString);
            return View("UpdateDatabase", updateElement);
        }


        //private List<Measurement.Models.Measurement> GetMeasurementParameters()
        //{
        //    List<Measurement.Models.Measurement> measurementList = new List<Measurement.Models.Measurement>();

        //    string connectionString = "Data Source=LTVALIASHVILINB;Initial Catalog=Measurement;Integrated Security=True";
        //    SqlConnection con = new SqlConnection(connectionString);

        //    string sqlQuery = "select MeasurementId, MeasurementName, Unit from Measurement where MeasurementID = 1";
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand(sqlQuery, con);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    if (dr != null)
        //    {
        //        while(dr.Read())
        //        {
        //            Measurement.Models.Measurement measurementParameter = new Measurement.Models.Measurement();

        //            measurementParameter.MeasurementId = Convert.ToInt32(dr["MeasurementId"]);
        //            measurementParameter.MeasurementName = dr["MeasurementName"].ToString();
        //            measurementParameter.MeasurementUnit = dr["Unit"].ToString();

        //            measurementList.Add(measurementParameter);
        //        }
        //    }
        //    return measurementList;
        //}
    }
}
