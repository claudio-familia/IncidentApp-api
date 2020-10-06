using IncidentApp.Models.Base;

namespace IncidentApp.Models
{
    public class SLA : EntityBase
    {
        public string Description { get; set; }
        public int Hours { get; set; }
    }
}
