using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPartManager
    {
        List<Part> GetAllParts();
        Part GetPartById(int id);
        public void AddPart(DtoPart part);
        public void UpdatePart(DtoPart part, int Id);
        public void DeletePart(int Id);
    }
}
