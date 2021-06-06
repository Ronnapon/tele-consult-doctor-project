using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.ViewModel;

namespace tele_consult.Data.Models.Services
{
    public class ClientsService
    {
        private AppDbContext _context;
        public ClientsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddNewClient(ClientVM client)
        {
            var _client = new Client()
            {
                FullName = client.FullName,
                Dob = client.Dob,
                Email = client.Email,
                Password = client.Password,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                Client_Payment_MethodId = client.Client_Payment_MethodId,
                CreditCard_Number = client.CreditCard_Number,
                CreditCard_CCV_Number = client.CreditCard_CCV_Number,
                CreditCard_ExpDate = client.Client_Payment_MethodId != 3 ? client.CreditCard_ExpDate.Value : null,
                CreditCard_Name = client.CreditCard_Name,
                Image = client.Image,
                DateAdded = DateTime.Now
            };
            _context.Clients.Add(_client);
            _context.SaveChanges();
        }
    }
}
