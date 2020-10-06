using IncidentApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models
{
    public class Priority : EntityBase
    {
        public int SLAId { get; set; }
        public string Name { get; set; }

        public SLA SLA { get; set; }
    }
}
