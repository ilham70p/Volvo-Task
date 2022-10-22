using Business.Abstract;
using DataAccesss.Abstract;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly IFeedbackDal _feedbackDal;

        public FeedbackManager(IFeedbackDal feedbackDal)
        {
            _feedbackDal = feedbackDal;
        }

        public void AddFeedback(FeedBack feedback)
        {
            FeedBack feed = new FeedBack {Title = feedback.Title,Description=feedback.Description,PartId = feedback.PartId,UserEmail=feedback.UserEmail };
            _feedbackDal.Add(feed);
        }

        public void DeleteFeedback(int Id)
        {
            
            _feedbackDal.Delete(_feedbackDal.Get(Id));
        }

        public List<FeedBack> GetAllFeedbacks()
        {
           return _feedbackDal.GetAll();
        }

        public FeedBack GetFeedbackById(int id)
        {
            return _feedbackDal.Get(id);
        }

        public void UpdateFeedback(DtoFeedback feedback, int Id)
        {
            FeedBack myfeed = _feedbackDal.Get(Id);
            myfeed.Title = feedback.Title;
            myfeed.Description = feedback.Description;
            myfeed.PartId = feedback.PartId;
            _feedbackDal.Update(myfeed);
        }
    }
}
