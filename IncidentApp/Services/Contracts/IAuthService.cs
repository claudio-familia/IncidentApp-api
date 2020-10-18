using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Services.Contracts
{
    public interface IAuthService
    {
        public IActionResult Login(string username, string password);
        public string Encrypt(string text);
        public string Decrypt(string text);        
    }
}
