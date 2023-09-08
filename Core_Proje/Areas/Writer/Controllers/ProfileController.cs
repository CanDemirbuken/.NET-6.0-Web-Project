using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.SurName;
            model.PictureURL = values.ImageURL;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEdit)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userEdit.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEdit.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);

                await userEdit.Picture.CopyToAsync(stream);
                user.ImageURL = imageName;
            }

            user.Name = userEdit.Name;
            user.SurName = userEdit.Surname;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEdit.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
