using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models;

namespace tele_consult.Data.ViewModel
{
    public class Client_UrgentVM
    {
        public string FullName { get; set; }
        public string Current_Address { get; set; }
        public string Description { get; set; }

        //Nevigator Properties
        public int ClientId { get; set; }
        public int DeseaseId { get; set; }
    }
}
