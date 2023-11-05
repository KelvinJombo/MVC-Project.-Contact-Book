using System.ComponentModel.DataAnnotations;

namespace WebViewContact.Models.Dtos
{
    public class AddContactDto
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
