using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var v = experienceManager.TGetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateExperience(int ExperienceID, string Name, string Date, string ImageURL, string Description)
        {
            var findValue = experienceManager.TGetByID(ExperienceID);

            if (findValue != null)
            {
                findValue.Name = Name;
                findValue.Date = Date;
                findValue.ImageURL = ImageURL;
                findValue.Description = Description;
                experienceManager.TUpdate(findValue);

                var values = JsonConvert.SerializeObject(findValue);
                return Json(values);
            }

            return NoContent();
        }
    }
}
