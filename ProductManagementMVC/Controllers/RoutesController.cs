using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementMVC.Controllers
{
    public class RoutesController : Controller
    {
        [Authorize]
        public ActionResult Product()
        {
            return PartialView();
        }
    }
}