using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Dtos
{
    public class IncidentDetailDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsClosed { get; set; }
        public List<IncidentHistoryDetailDto> Histories { get; set; }
    }

    public class IncidentHistoryDetailDto
    {
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }        
    }
}
