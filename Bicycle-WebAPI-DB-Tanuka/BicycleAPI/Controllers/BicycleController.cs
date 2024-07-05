using BicycleAPI.AOP;
using BicycleAPI.Exceptions;
using BicycleAPI.Logging;
using BicycleAPI.Models;
using BicycleAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleAPI.Controllers
{
    [ServiceFilter(typeof(BicycleLogger))]
    [BicycleExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        readonly IBicycleService _bicycleService;
        public BicycleController(IBicycleService bicycleService)
        {
            _bicycleService = bicycleService;
        }
        [HttpGet]
        [Route("getAllBicycles")]
        public ActionResult GetAllBicycles()
        {
            List<Bicycle> bicycles = _bicycleService.GetAllBicycles();
            return Ok(bicycles);
        }

        [HttpPost]
        [Route("addBicycle")]
        public ActionResult AddBicycle(Bicycle bicycle)
        {
            int bicycleAddResult = _bicycleService.AddBicycle(bicycle);
            return Created("api/addbicycle", bicycleAddResult);
        }

        [HttpDelete]
        [Route("deleteBicycle")]
        public ActionResult DeleteBicycle(int bicycleId)
        {
            bool bicycleDeleteResult = _bicycleService.DeleteBicycle(bicycleId);
            return Ok(bicycleDeleteResult);
        }

        [HttpPut]
        [Route("editBicycle")]
        public ActionResult EditBicycle(int id, Bicycle newBicycle)
        {
            bool bicycleEditResult = _bicycleService.EditBicycle(id, newBicycle);
            return Ok(bicycleEditResult);
        }
    }
}
