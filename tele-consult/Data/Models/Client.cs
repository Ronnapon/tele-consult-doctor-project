using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.Models
{
    public class Client
    {
       public int Id { get; set; }
       public string FullName { get; set; }
       public DateTime Dob { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string PhoneNumber { get; set; }
       public string Address { get; set; }
       public string CreditCard_Number { get; set; }
       public string CreditCard_CCV_Number { get; set; }
       public DateTime? CreditCard_ExpDate { get; set; }
       public string CreditCard_Name { get; set; }
       public string Image { get; set; }
       public DateTime DateAdded { get; set; }

        // Nevigator Properties
        public int Client_Payment_MethodId { get; set; }
        public Client_Payment_Method client_Payment_Method { get; set; }
        public List<Client_Urgent> client_Urgents { get; set; }
    }
}
