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


        public List<Client> GetAllClients(string searchName)
        {
            var client = _context.Clients.ToList();
            if (!string.IsNullOrEmpty(searchName))
            {
                client = client.Where(n => n.FullName.Contains(searchName,
                    StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return client;
        }

        public Client GetClient(int Id)
        {
            var client = _context.Clients.FirstOrDefault(n => n.Id == Id);
            return client;
        }

        public void DeleteClient(int Id)
        {
            var client = _context.Clients.FirstOrDefault(n => n.Id == Id);
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public void UpdateClient(ClientVM client,int Id)
        {
            var _client = _context.Clients.FirstOrDefault(n => n.Id == Id);
            if (_client != null)
            {
                _client.FullName = client.FullName;
                _client.Dob = client.Dob;
                _client.Email = client.Email;
                _client.PhoneNumber = client.PhoneNumber;
                _client.Address = client.Address;
                _client.Client_Payment_MethodId = client.Client_Payment_MethodId;
                _client.CreditCard_Number = client.CreditCard_Number;
                _client.CreditCard_CCV_Number = client.CreditCard_CCV_Number;
                _client.CreditCard_ExpDate = client.Client_Payment_MethodId != 3 ? client.CreditCard_ExpDate.Value : null;
                _client.CreditCard_Name = client.CreditCard_Name;
                _client.Image = client.Image;
            }
            _context.SaveChanges();
        }
    }
}
