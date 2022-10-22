using Business.Concrete;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Volvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly PartManager _manager;

        public PartController(PartManager manager)
        {
            _manager = manager;
        }


        [HttpGet("GetAll")]
        public List<Part> GetAll() {

            return _manager.GetAllParts();
        
        }


        [HttpGet("GetById")]
        public Part Get([FromForm]int id) {

            return _manager.GetPartById(id);
        
        }


        [HttpPost("Add"),Authorize(Roles ="Factory")]
        public void Add([FromForm]DtoPart part) {

            _manager.AddPart(part);
        
        }

        [HttpPut("Update"),Authorize(Roles = "Manager,Tester,Factory")]
        public void Update(int Id,[FromForm] DtoPart part) {
            
            _manager.UpdatePart(part,Id);
        
        }

        [HttpDelete("Delete"),Authorize(Roles = "Tester,Manager,Factory")]
        public void Delete(int Id) {
            _manager.DeletePart(Id);
        
        }

    }
}
