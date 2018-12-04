using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIST.Data;
using Microsoft.AspNetCore.Mvc;

namespace LIST.Areas.Leerling.Controllers
{
    [Area("Leerling")]
    [Route("leerling/[controller]")]
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
        
    }
}