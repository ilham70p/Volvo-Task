﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DtoFeedbackCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PartId { get; set; }
    }
}
