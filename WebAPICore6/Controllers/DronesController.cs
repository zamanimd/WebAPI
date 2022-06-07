using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPICore6.Model;

namespace WebAPICore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {

        //private readonly ILogger<DronesController> _logger;

        //public DronesController(ILogger<DronesController> logger)
        //{
        //    _logger = logger;
        //}


        static string dbDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"Data\\{"db_Drone.json"}");
        string jsonData = System.IO.File.ReadAllText(dbDirectory);

        public List<Drone> lst_drones = new List<Drone>()
        {
            new Drone(1,"SwissDrone","This drone is the best SwissDrone's Drone."),
            new Drone(2,"Anavia","This drone is the best Anavia's Drone."),
            new Drone(2,"DJI Mini","This drone is the best DGI's Drone.")
        };




        #region Create

        //--- Create ---//
        [HttpPost]
        public IActionResult AddDrone(Drone drone)
        {
            if (drone == null)
                return BadRequest();

            lst_drones.Add(drone);
            return Ok();
        }

        #endregion




        #region Read

        //--- Read ---//
        //[HttpGet]
        //public IActionResult GetDrones()
        //{
        //    if (string.IsNullOrWhiteSpace(jsonData))
        //        return BadRequest();

        //    var drones = JsonConvert.DeserializeObject<List<Drone>>(jsonData);

        //    if (drones == null || drones.Count == 0)
        //        BadRequest();

        //    //var user = users.FirstOrDefault(x => x.FirstName == firstName);

        //    return Ok(drones);
        //}


        //--- Read ---//
        [HttpGet("all")]
        public IActionResult GetDrones()
        {
            if (string.IsNullOrWhiteSpace(jsonData))
                return BadRequest();

            var drones = JsonConvert.DeserializeObject<List<Drone>>(jsonData);

            if (drones == null || drones.Count == 0)
                BadRequest();

            return Ok(drones);
        }


        //--- Read ---//
        [HttpGet("{id}")]
        public IActionResult GetDrones(int id)
        {
            if (string.IsNullOrWhiteSpace(jsonData))
                return BadRequest();

            var drones = JsonConvert.DeserializeObject<List<Drone>>(jsonData);

            if (drones == null || drones.Count == 0)
                BadRequest();

            var drone = drones.FirstOrDefault(x => x.Id == id);

            return Ok(drone);
        }

        #endregion




        #region Update

        //--- Update ---//
        [HttpPut]
        public IActionResult InsertDrone(Drone drone)
        {
            if (drone == null)
                return BadRequest();

            foreach (Drone item in lst_drones)
            {
                if (drone.Id == item.Id)
                {
                    item.Name = drone.Name;
                    item.Description = drone.Description;
                    return Ok();
                }
            }
            return BadRequest();
        }

        #endregion




        #region Delete

        //--- Delete ---//
        [HttpDelete]
        public IActionResult DeleteDrone()
        {
            lst_drones.Clear();

            if (lst_drones.Any())
                return Ok();

            return BadRequest();
        }

        //--- Delete ---//
        [HttpDelete("{id}")]
        public IActionResult DeleteDrone(int id)
        {
            lst_drones.Clear();

            if (lst_drones.Any())
                return Ok();

            return BadRequest();
        }

        #endregion

    }
}
