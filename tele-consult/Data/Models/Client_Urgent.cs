using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Client_Urgent
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Current_Address { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

        // Nevigator Properties
        public int ClientId { get; set; }
        public Client client { get; set; }
        public int DeseaseId { get; set; }
        public Desease desease { get; set; }
    }
}
