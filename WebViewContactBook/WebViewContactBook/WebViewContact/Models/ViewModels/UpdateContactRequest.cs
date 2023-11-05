using System.ComponentModel.DataAnnotations;

namespace WebViewContact.Models.ViewModels
{
    public class UpdateContactRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
