using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models;

namespace MovieShop.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginResponseModel userLoginResponseModel)
        {
            return View();
        }
    }
}