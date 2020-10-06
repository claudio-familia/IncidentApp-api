using IncidentApp.Models.Base;

namespace IncidentApp.Models
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
