using IncidentApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models
{
    public class Incident : EntityBase
    {
        public int ReportedUserId { get; set; }
        public int AssignedUserId { get; set; }
        public int PriorityId { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ClosedDate { get; set; }
        public string ClosedComment { get; set; }

        #region relations

        public Priority Priority { get; set; }
        public Department Department { get; set; }
        public User ReportedUser { get; set; }
        public User AssignedUser { get; set; }

        #endregion
    }
}
