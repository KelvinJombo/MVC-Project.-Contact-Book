using Microsoft.AspNetCore.Mvc;
using WebViewContact.WebViewContact.Core.IRepository;

namespace WebViewContact.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult GetById()
        {
            // Display a form for the user to enter an ID
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fetchedUser = await userRepository.GetById(id);

            if (fetchedUser == null)
            {
                
                return View("UserNotFound"); 
            }

            return View(fetchedUser);
        }



    }
}
