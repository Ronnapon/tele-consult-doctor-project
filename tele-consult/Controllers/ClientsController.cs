using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using tele_consult.Data.ViewModel;

namespace tele_consult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public ClientsService _clientsService;
        public ClientsController(ClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpPost]
        public IActionResult AddNewClient([FromBody] ClientVM client)
        {
            // Check Validate
            if(ValidatePaymentMethod(client) != "")
            {
                return BadRequest(ValidatePaymentMethod(client));
            }

            _clientsService.AddNewClient(client);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllClients(string search)
        {
            // Check Validate
            var clients = _clientsService.GetAllClients(search);
            return Ok(clients);
        }

        [HttpGet("{Id}")]
        public IActionResult GetClient(int Id)
        {
            var clients = _clientsService.GetClient(Id);
            return Ok(clients);
        }

        [HttpPut("{Id}")]
        public IActionResult AddNewClient([FromBody] ClientVM client, int Id)
        {
            // Check Validate
            if (ValidatePaymentMethod(client) != "")
            {
                return BadRequest(ValidatePaymentMethod(client));
            }

            _clientsService.UpdateClient(client,Id);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteClient(int Id)
        {
            _clientsService.DeleteClient(Id);
            return Ok();
        }

        private string ValidatePaymentMethod(ClientVM client)
        {
            var ErrorMessge = ""; 
            if (client.Client_Payment_MethodId == 3)
            {
                if (client.CreditCard_Number == ""
                    || client.CreditCard_CCV_Number == ""
                    || client.CreditCard_Name == "")
                {
                    ErrorMessge =  "CreditCard Information is requited";
                }
            }
            else
            {
                if (client.CreditCard_Number != ""
                   || client.CreditCard_CCV_Number != ""
                   || client.CreditCard_Name != "")
                {
                    ErrorMessge = "CreditCard Information is not requited";
                }
            }
            return ErrorMessge;
        }
    }
}
