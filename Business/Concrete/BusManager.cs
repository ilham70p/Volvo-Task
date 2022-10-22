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
    public class BusManager : IBusManager
    {
        private readonly IBusDal _busDal;

        public BusManager(IBusDal busDal)
        {
            _busDal = busDal;
        }


        public void AddBus(DtoBus bus)
        {
            Bus mybus = new Bus {Name = bus.Name };
            _busDal.Add(mybus);
        }

        public void DeleteBus(int Id)
        {
            Bus mybus = _busDal.Get(Id);
            _busDal.Delete(mybus);
        }

        public List<Bus> GetAllBusses()
        {
          return  _busDal.GetAll();
        }

        public Bus GetBusById(int id)
        {
           return _busDal.Get(id);
        }

        public void UpdateBus(DtoBus bus, int Id)
        {
            Bus mybus = _busDal.Get(Id);
            mybus.Name = bus.Name;
            _busDal.Update(mybus);
        }
    }
}
