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
        [HttpPost("Add{drone}")]
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
        [HttpGet("GetAll")]
        public IActionResult GetDrones()
        {
            try
            {
                DataManager dataManager = new DataManager();
                var drones = dataManager.ReadAllData();

                if (drones == null || drones.Count == 0)
                    return NotFound();

                return Ok(drones);
            }
            catch
            {
                return BadRequest();
            }
        }


        //--- Read ---//
        [HttpGet("GetByID{id}")]
        public IActionResult GetDroneByID(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                var drone = dataManager.ReadData(id);

                if (drone == null)
                    return NotFound();

                return Ok(drone);
            }
            catch
            {
                return BadRequest();
            }
        }

        //--- Read ---//
        [HttpGet("GetByName{name}")]
        public IActionResult GetDroneByName(string name)
        {
            try
            {
                if (name == null || String.IsNullOrWhiteSpace(name))
                    return BadRequest();

                DataManager dataManager = new DataManager();
                var drone = dataManager.ReadData(name);

                if (drone == null)
                    return NotFound();

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
        [HttpPut("RecoverAll")]
        public IActionResult RecoverDrones()
        {
            try
            {
                DataManager dataManager = new DataManager();
                bool status = dataManager.RecoverAllData();

                if (!status)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //--- Update ---//
        [HttpPut("RecoverByID{id}")]
        public IActionResult RecoverDroneByID(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.RecoverData(id);

                if (!status)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //--- Update ---//
        [HttpPut("UpdateByDrone")]
        public IActionResult UpdateDrone(Drone drone)
        {
            try
            {
                if (drone == null)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.UpdateData(drone);

                if (!status)
                    return NotFound();

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
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteDrones()
        {
            try
            {
                DataManager dataManager = new DataManager();
                bool status = dataManager.RemoveAllData();

                if (!status)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        //--- Delete ---//
        [HttpDelete("DeleteByID{id}")]
        public IActionResult DeleteDroneByID(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.RemoveData(id);

                if (!status)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //--- Delete ---//
        [HttpDelete("DeleteByName{name}")]
        public IActionResult DeleteDroneByName(string name)
        {
            try
            {
                if (name == null || string.IsNullOrWhiteSpace(name))
                    return BadRequest();

                DataManager dataManager = new DataManager();
                bool status = dataManager.RemoveData(name);

                if (!status)
                    return NotFound();

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
