using System;

namespace IncidentApp.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }
    }
}
