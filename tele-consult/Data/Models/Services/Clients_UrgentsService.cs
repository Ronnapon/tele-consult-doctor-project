using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.ViewModel;

namespace tele_consult.Data.Models.Services
{
    public class Clients_UrgentsService
    {
        private AppDbContext _context;
        public Clients_UrgentsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddNewClient_Urgent(Client_UrgentVM client)
        {
            var _client = new Client_Urgent()
            {
                FullName = client.FullName,
                Current_Address = client.Current_Address,
                Description = client.Description,
                ClientId = client.ClientId,
                DeseaseId = client.DeseaseId,
                DateAdded = DateTime.Now
            };
            _context.Client_Urgents.Add(_client);
            _context.SaveChanges();
        }
    }
}
