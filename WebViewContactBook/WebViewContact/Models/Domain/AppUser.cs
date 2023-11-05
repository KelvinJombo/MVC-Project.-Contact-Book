using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebViewContact.Models.Domain
{
    public class AppUser
    {
        [Key]
        public Guid Id { get; set; }    
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("Contact")]
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
