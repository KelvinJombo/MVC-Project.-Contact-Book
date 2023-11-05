using Microsoft.AspNetCore.Mvc;
using WebViewContact.Models.Domain;

namespace WebViewContact.WebViewContact.Core.IRepository
{
    public interface IUserRepository
    {
        Task<Contact> GetById(Guid id);
    }
}
