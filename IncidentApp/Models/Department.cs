using IncidentApp.Models.Base;
using System.Collections.Generic;

namespace IncidentApp.Models
{
    public class Department : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
