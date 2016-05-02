using Day1Homework.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Areas.skilltree.Controllers
{
    public class MoneyController : Controller
    {
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}