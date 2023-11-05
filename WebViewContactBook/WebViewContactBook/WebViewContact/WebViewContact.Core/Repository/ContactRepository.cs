using Microsoft.EntityFrameworkCore;
using WebViewContact.Models.Domain;
using WebViewContact.WebViewContact.Core.IRepository;
using WebViewContact.WebViewContact.Data;

namespace WebViewContact.WebViewContact.Core.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly WebViewDbContext webViewDbContext;

        public ContactRepository(WebViewDbContext webViewDbContext)
        {
            this.webViewDbContext = webViewDbContext;
        }


        public async Task<Contact> AddAsync(Contact contact)
        {
            await webViewDbContext.Contacts.AddAsync(contact);
            await webViewDbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact?> DeleteAsync(Guid id)
        {
             var existingContact = await webViewDbContext.Contacts.FindAsync(id);

            if (existingContact != null)
            {
                webViewDbContext.Contacts.Remove(existingContact);
                await webViewDbContext.SaveChangesAsync();
                return existingContact;
            }
            return null;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await webViewDbContext.Contacts.ToListAsync();
        }

        public Task<Contact?> GetAsync(Guid id)
        {
             return webViewDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact?> UpdateAsync(Contact contact)
        {
            var existingContact = await webViewDbContext.Contacts.FindAsync(contact.Id);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Address = contact.Address;
                existingContact.PhoneNumber = contact.PhoneNumber;

                await webViewDbContext.SaveChangesAsync();

                return existingContact;
            }

            return null;
        }
    }
}
