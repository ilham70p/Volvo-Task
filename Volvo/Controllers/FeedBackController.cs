using Business.Abstract;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Volvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedbackManager _manager;

        public FeedBackController(IFeedbackManager manager)
        {
            _manager = manager;
        }
        [HttpGet("GetAll"),Authorize(Roles ="Manager")]
        public List<FeedBack> GetAll() {
        
        return _manager.GetAllFeedbacks();
        
        }

        [HttpGet("GetById"),Authorize(Roles ="Manager")]
        public FeedBack GetById(int id) {

            return _manager.GetFeedbackById(id);
        
        }

        [HttpPost("Add"),Authorize]
        public string Add(DtoFeedbackCreate feedback) {

            FeedBack feed = new FeedBack { Title = feedback.Title, Description = feedback.Description, PartId = feedback.PartId, UserEmail = getuser() };
            _manager.AddFeedback(feed);
            return feed.UserEmail;
        }

        [HttpPut("Update"),Authorize]
        public void Update(int Id,DtoFeedback feedback) {
           
            _manager.UpdateFeedback(feedback,Id);

        }

        [HttpDelete("Delete"),Authorize]
        public void Delete(int Id) { 
        
            _manager.DeleteFeedback(Id);
        
        }





        private string getuser() {

            return User.Identity.Name;
        
        }

    }
}
