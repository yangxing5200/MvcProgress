using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Protal.Common;

namespace Protal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProgress(string guid)
        {
            return Json(HttpContext.Cache[guid]);
        }

        public ActionResult Abort(string guid)
        {
            HttpContext.Cache[guid] = null;
            return Json("ok");
        }

        public ActionResult Exec(string guid)
        {
            MessageFactory.GenMsg(guid);
            return Json("ok");
        }

    }
}
