using System;

namespace IncidentApp.Models.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #region relations

        public User Creator { get; set; }
        public User Updater { get; set; }        

        #endregion
    }
}
