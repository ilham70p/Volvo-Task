using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBusManager
    {
        List<Bus> GetAllBusses();
        Bus GetBusById(int id);
        public void AddBus(DtoBus bus);
        public void UpdateBus(DtoBus bus,int Id);
        public void DeleteBus(int Id);
    }
}
