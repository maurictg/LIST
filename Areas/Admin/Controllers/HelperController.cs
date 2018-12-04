using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LIST.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class HelperController : Controller
    {

        public ContentResult Hash()
        {
            if (Request.QueryString != null)
            {
                string input = HttpContext.Request.QueryString.ToString().Replace("?", "");
                return Content(LIST.Classes.Encryption.HASH.hashPBKDF2(input, 10000) + "<br>" + input);
            }
            else
            {
                return Content("NULL");
            }

        }

        public ContentResult GetUsername()
        {
            return Content(Environment.UserName.ToString());
        }

        public IActionResult NF()
        {
            return NotFound();
        }

        public ContentResult getToken()
        {
            return Content(HttpContext.Session.GetString("Token"));
        }
    

    }
}