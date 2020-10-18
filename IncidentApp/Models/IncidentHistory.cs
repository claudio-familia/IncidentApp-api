using IncidentApp.Models.Base;

namespace IncidentApp.Models
{
    public class IncidentHistory : EntityBase
    {
        public int IncidentId { get; set; }
        public string Comment { get; set; }

        #region relations

        public Incident Incident { get; set; }

        #endregion
    }
}
