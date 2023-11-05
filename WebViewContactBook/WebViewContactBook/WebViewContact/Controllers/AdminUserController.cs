using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebViewContact.Models.Domain;
using WebViewContact.Models.Dtos;
using WebViewContact.Models.ViewModels;
using WebViewContact.WebViewContact.Core.IRepository;
using WebViewContact.WebViewContact.Data;

namespace WebViewContact.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly IContactRepository contactRepository;

        public AdminUserController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Add")]
        public async Task <IActionResult> SaveContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact
            {
                FirstName = addContactRequest.FirstName,
                LastName = addContactRequest.LastName,
                Address = addContactRequest.Address,
                PhoneNumber = addContactRequest.PhoneNumber,
            };
                await contactRepository.AddAsync(contact);

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            //Use DbContext to read the tags

            var contacts = await contactRepository.GetAllAsync();

            return View(contacts);
        }




        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
             var contact = await contactRepository.GetAsync(id);
            if(contact != null)
            {
                var updateContactRequest = new UpdateContactRequest
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Address = contact.Address,
                    PhoneNumber = contact.PhoneNumber,
                };
                
                return View(updateContactRequest);
                                 
            };

            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactRequest updateContactRequest)
        {
            var contact = new Contact
            {
                Id = updateContactRequest.Id,
                FirstName = updateContactRequest.FirstName,
                LastName = updateContactRequest.LastName,
                Address = updateContactRequest.Address,
                PhoneNumber = updateContactRequest.PhoneNumber,
            };

             

            var updatedContact = await contactRepository.UpdateAsync(contact);

            if(updatedContact != null)
            {
                //Show Success Notification
                //return View(updatedContact);

            }
            //Show Failure Notification
            return RedirectToAction("Update", new { id = updateContactRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateContactRequest updateContactRequest)
        { 
             var deletedContact = await contactRepository.DeleteAsync(updateContactRequest.Id);

            if(deletedContact != null)
            {
                //Show Success Notification
                return RedirectToAction("List");
            }

            //Show an error Notification
            return RedirectToAction("Update", new { Id = updateContactRequest.Id });
        }
    }
        
}
