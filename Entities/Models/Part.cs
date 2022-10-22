using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Part:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Bus")]
        public int BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
