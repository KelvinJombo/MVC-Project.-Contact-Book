using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebViewContact.Models.Domain;
using WebViewContact.WebViewContact.Core.IRepository;
using WebViewContact.WebViewContact.Data;

namespace WebViewContact.WebViewContact.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WebViewDbContext webViewDbContext;

        public UserRepository(WebViewDbContext webViewDbContext)
        {
            this.webViewDbContext = webViewDbContext;
        }


        public async Task<Contact> GetById(Guid id)
        {
            var contact = await webViewDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact == null)
            {
                return null;
            }

            return contact;
        }

         
    }
}
