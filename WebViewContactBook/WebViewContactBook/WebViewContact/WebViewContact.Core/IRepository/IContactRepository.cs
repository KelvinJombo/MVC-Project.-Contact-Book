using System.Collections;
using System.Collections.Generic;
using WebViewContact.Models.Domain;

namespace WebViewContact.WebViewContact.Core.IRepository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();

        Task<Contact?> GetAsync(Guid id);

        Task<Contact> AddAsync(Contact contact);
        Task<Contact?> UpdateAsync(Contact contact);

        Task<Contact?> DeleteAsync(Guid id);
    }
}
