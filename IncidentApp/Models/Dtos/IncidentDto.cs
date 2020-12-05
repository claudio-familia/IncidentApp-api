using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Dtos
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public int ReportedUserId { get; set; }
        public int? AssignedUserId { get; set; }
        public int PriorityId { get; set; }
        public int? DepartmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string ClosedComment { get; set; }
        public bool? IsIncidentClosed { get; set; }
    }
}
