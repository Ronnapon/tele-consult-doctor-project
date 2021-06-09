using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime DateOfJoing { get; set; }

        // Nevigator properties
        public int RoleId { get; set; }
        public Role role { get; set; }
    }
}
