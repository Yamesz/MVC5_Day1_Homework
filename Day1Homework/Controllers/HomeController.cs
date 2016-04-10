using Day1Homework.Models.ViewModels;
using Day1Homework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CategoryList = CategoryGet();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyRecordList()
        {
            List<MoneyRecordViewModels> MoneyRecordList = FakeMoneyRecordGet();
            return View(MoneyRecordList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region private 方法

        private static IEnumerable<SelectListItem> CategoryGet()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "請選擇", Value = "", Selected = true });
            items.Add(new SelectListItem() { Text = "支出", Value = "pay", Selected = false });
            items.Add(new SelectListItem() { Text = "收入", Value = "income", Selected = false });
            return items;
        }

        private static List<MoneyRecordViewModels> FakeMoneyRecordGet()
        {
            return new List<MoneyRecordViewModels>
            {
                new MoneyRecordViewModels { category="支出",money=100,date="2016-01-01".ToDateTime() },
                new MoneyRecordViewModels { category="支出",money=200,date="2016-01-02".ToDateTime() },
                new MoneyRecordViewModels { category="支出",money=300,date="2016-01-03".ToDateTime() },
                new MoneyRecordViewModels { category="收入",money=400,date="2016-01-04".ToDateTime() },
            };
        }

        #endregion
    }
}