using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIST.Data;
using LIST.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LIST.Areas.Leerling.Controllers
{
    [Area("Leerling")]
    [Route("leerling/[controller]/[action]")]
    public class ProfielkeuzeController : Controller
    {
        // GET: LOB/Profiel
        private readonly LOBContext _context;

        public ProfielkeuzeController(LOBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Profielen);
        }

        public ActionResult Kiezen()
        {
            int? code = HttpContext.Session.GetInt32("Studentcode");
            if (code != null)
            {
                var data = _context.Profielkeuze
                                   .Where(s => s.Studentcode == code)
                                   .FirstOrDefault();
                return View(data);
            }
            else
            {
                return View();
            }
        }

        //Tutorial: http://www.entityframeworktutorial.net/efcore/saving-data-in-connected-scenario-in-ef-core.aspx
        [HttpPost]
        public IActionResult KeuzeOpslaan(Profile profiel)
        {
            int? code = HttpContext.Session.GetInt32("Studentcode");
            var data = _context.Profielkeuze
                                  .Where(s => s.Studentcode == code)
                                  .FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    data.Profilename = profiel.Profilename;
                    _context.SaveChanges();

                    ViewBag.Message = "[Suc]Wijzigingen opgeslagen!";
                    return View("Kiezen", data);

                }
                else
                {
                    ViewBag.Message = "[Err]Gegevens onjuist";
                    return View("Kiezen", data);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "[Err]Opslaan mislukt, "+ex.ToString();
                return View("Kiezen", data);
            }

        }
    }
}