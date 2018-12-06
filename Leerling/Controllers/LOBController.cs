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
    public class LOBController : Controller
    {
        private readonly LOBContext _context;

        public LOBController(LOBContext context)
        {
            _context = context;
        }
        // GET: LOB/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}