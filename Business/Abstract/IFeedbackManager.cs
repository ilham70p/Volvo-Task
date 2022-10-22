using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeedbackManager
    {
        List<FeedBack> GetAllFeedbacks();
        FeedBack GetFeedbackById(int id);
        public void AddFeedback(FeedBack feedback);
        public void UpdateFeedback(DtoFeedback feedback, int Id);
        public void DeleteFeedback(int Id);
    }
}
