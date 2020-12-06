using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Dtos
{
    public class IncidentHistoryResponseDto
    {
        public int Id { get; set; }
        public string Incident { get; set; }
        public string Priority { get; set; }
        public string Responsable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public string TimeToClose { get; set; }
    }
}
