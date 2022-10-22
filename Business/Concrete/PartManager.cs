using Business.Abstract;
using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PartManager : IPartManager
    {
        private readonly IPartDal _partDal;

        public PartManager(IPartDal partDal)
        {
            _partDal = partDal;
        }

        public void AddPart(DtoPart part)
        {
           Part mypart = new Part {Name=part.Name,BusId=part.BusId };
            _partDal.Add(mypart);
        }

        public void DeletePart(int Id)
        {
            _partDal.Delete(_partDal.Get(Id));
        }

        public List<Part> GetAllParts()
        {
        return   _partDal.GetAll();
        }

        public Part GetPartById(int id)
        {
            return _partDal.Get(id);
        }

        public void UpdatePart(DtoPart part, int Id)
        {
            Part mypart = _partDal.Get(Id);
            mypart.BusId = part.BusId;
            mypart.Name = part.Name;
            _partDal.Update(mypart);
        }
    }
}
