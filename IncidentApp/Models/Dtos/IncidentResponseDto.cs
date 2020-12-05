using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Dtos
{
    public class IncidentResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string AssignTo { get; set; }
        public bool IsQueueDone { get; set; }
        public bool IsProcessDone { get; set; }
        public bool IsClosed { get; set; }
    }
}
