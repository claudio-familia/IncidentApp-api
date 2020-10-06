using IncidentApp.Models.Base;

namespace IncidentApp.Models
{
    public class Position : EntityBase
    {
        public string Name { get; set; }        
        public int DepartmentId { get; set; }

        #region relations

        public Department Department { get; set; }

        #endregion
    }
}
