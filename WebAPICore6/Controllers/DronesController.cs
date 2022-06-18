using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPICore6.Data;
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


        #region Create

        //--- Create ---//
        [HttpPost]
        public IActionResult AddDrone(Drone drone)
        {
            try
            {
                if (drone == null)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.AddData(drone);

                if (!status)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion




        #region Read

        //--- Read ---//
        //[HttpGet]
        //public IActionResult GetDrones()
        //{
        //    DataManager dataManager = new DataManager();
        //    var drones = dataManager.lst_Drones();

        //    if (drones == null || drones.Count == 0)
        //        return BadRequest();

        //    return Ok(drones);
        //}


        //--- Read ---//
        [HttpGet("all")]
        public IActionResult GetDrones()
        {
            try
            {
                DataManager dataManager = new DataManager();
                var drones = dataManager.ReadAllData();

                if (drones == null || drones.Count == 0)
                    return BadRequest();

                return Ok(drones);
            }
            catch
            {
                return BadRequest();
            }
        }


        //--- Read ---//
        [HttpGet("{id}")]
        public IActionResult GetDrone(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                var drone = dataManager.ReadData(id);

                if (drone == null)
                    return BadRequest();

                return Ok(drone);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion




        #region Update

        //--- Update ---//
        [HttpPut]
        public IActionResult UpdateDrone(Drone drone)
        {
            try
            {
                if (drone == null)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.AddData(drone);

                if (!status)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //--- Update ---//
        [HttpPut("recovery")]
        public IActionResult RecoveryDrone(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.RecoverData(id);

                if (!status)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion




        #region Delete

        //--- Delete ---//
        [HttpDelete]
        public IActionResult DeleteDrones()
        {
            try
            {
                DataManager dataManager = new DataManager();
                bool status = dataManager.RemoveAllData();

                if (!status)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        //--- Delete ---//
        [HttpDelete("{id}")]
        public IActionResult DeleteDroneBy(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.RemoveData(id);

                if (!status)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

    }
}
