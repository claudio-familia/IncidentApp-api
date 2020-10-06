using IncidentApp.Models.Base;
using System;

namespace IncidentApp.Models
{
    public class Employee : EntityBase
    {
        public int PositionId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }

        #region relations

        public User User { get; set; }
        public Position Position { get; set; }

        #endregion
    }
}
