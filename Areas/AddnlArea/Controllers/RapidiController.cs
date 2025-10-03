using coremvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace coremvc.Area.AddnlArea.Controllers
{
    [Area("AddnlArea")]
    public class RapidiController : Controller
    {
        public IActionResult Index()
        {
            List<Student> st = new List<Student>()
            {
                new Student()
                {
                    roll=1, name="kaka", gender="Male", age=32, dob = new DateTime(2000,09,02),course="MPC",
                },
                new Student()
                {
                    roll=2, name="kanta", gender="FeMale", age=35, dob = new DateTime(2005,01,12),course="MPC",
                },
                new Student()
                {
                    roll=3, name="gaddi", gender="FeMale", age=38, dob = new DateTime(2001,01,06),course="MPC",
                },
                new Student()
                {
                    roll=4, name="beda", gender="Male", age=89, dob = new DateTime(2002,04,02),course="MPC",
                },
                new Student()
                {
                    roll=5, name="poolu", gender="Male", age=69, dob = new DateTime(2003,03,02),course="MPC",
                }

            };
            return View(st);
        }
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Rapidi()
        {
            return View();
        }
    }
}
