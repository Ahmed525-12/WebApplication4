using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;

		public AuthController(UserManager<ApplicationUser> userManager)
		{
			this.userManager = userManager;
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAsync(RegisterVM model)
		{
			if (ModelState.IsValid)
			{
				var User = new ApplicationUser()
				{
					UserName = model.Email.Split("@")[0],
					Email = model.Email,
					LName = model.LName,
					FName = model.FName,
					isAgree = model.isAgree
				};
				var result = await userManager.CreateAsync(User, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("LogIn");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View(model);
		}
	}
}