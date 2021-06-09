using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tele_consult.Data.ViewModel
{
    public class ClientVM
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1, 3)]
        public int Client_Payment_MethodId { get; set; }
        [CreditCard]
        public string CreditCard_Number { get; set; }
        public string CreditCard_CCV_Number { get; set; }
        public DateTime? CreditCard_ExpDate { get; set; }  
        public string CreditCard_Name { get; set; }

        [Url]
        public string Image { get; set; }
    }
}

//[ValidateNever]: The ValidateNeverAttribute indicates that a property or parameter should be excluded from validation.
//[CreditCard]: Validates that the property has a credit card format. Requires jQuery Validation Additional Methods.
//[Compare]: Validates that two properties in a model match.
//[EmailAddress]: Validates that the property has an email format.
//[Phone]: Validates that the property has a telephone number format.
//[Range]: Validates that the property value falls within a specified range.
//[RegularExpression]: Validates that the property value matches a specified regular expression.
//[Required]: Validates that the field is not null. See [Required] attribute for details about this attribute's behavior.
//[StringLength]: Validates that a string property value doesn't exceed a specified length limit.
//[Url]: Validates that the property has a URL format.
//[Remote]: Validates input on the client by calling an action method on the server.See[Remote] attribute for details about this attribute's behavior.
