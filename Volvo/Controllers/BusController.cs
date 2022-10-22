using Business.Abstract;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Volvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BusController : ControllerBase
    {
        private readonly IBusManager _manager;

        public BusController(IBusManager manager)
        {
            _manager = manager;
        }


        [HttpGet("GetAll")]
        public List<Bus> Getall() {
            return _manager.GetAllBusses();
        }

        [HttpGet("GetById")]
        public Bus Get(int id) {
        
       return _manager.GetBusById(id);
        
        }


        [HttpPost("AddBus"),Authorize(Roles = "Factory")]
        public void AddBus([FromForm] DtoBus bus) {
        
        _manager.AddBus(bus);
        
        }

        [HttpPut("UpdateBus"),Authorize(Roles ="Factory")]
        public void UpdateBus([FromForm]int Id,[FromForm] DtoBus bus) {

            _manager.UpdateBus(bus,Id);
        
        }

        [HttpDelete("DeleteBus"),Authorize(Roles ="Factory")]
        public void DeleteBus([FromForm] int Id) {

            _manager.DeleteBus(Id);
        
        }


    }
}
