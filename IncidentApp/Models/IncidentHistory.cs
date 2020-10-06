using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models
{
    public class IncidentHistory
    {
        public int IncidentId { get; set; }
        public string Comment { get; set; }

        public Incident Incident { get; set; }
    }
}
