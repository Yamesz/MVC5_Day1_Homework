using AutoMapper;
using Day1Homework.Models;
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
        private Money db = new Money();
        public ActionResult Index()
        {
            ViewBag.CategoryList = CategoryGet();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyRecordList()
        {
            //List<MoneyRecordViewModels> MoneyRecordList = FakeMoneyRecordGet();
            var model = db.AccountBook.Take(5).ToList();
            List<MoneyRecordViewModels> moneyRecordList =
                Mapper.Map<List<MoneyRecordViewModels>>(model);

            return View(moneyRecordList);
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
            items.Add(new SelectListItem() { Text = "支出", Value = "0", Selected = false });
            items.Add(new SelectListItem() { Text = "收入", Value = "1", Selected = false });
            return items;
        }

        private static List<MoneyRecordViewModels> FakeMoneyRecordGet()
        {
            return new List<MoneyRecordViewModels>
            {
                new MoneyRecordViewModels { category=0,money=100,date=new DateTime(2016,1,1) },
                new MoneyRecordViewModels { category=0,money=200,date=new DateTime(2016,1,2) },
                new MoneyRecordViewModels { category=0,money=300,date=new DateTime(2016,1,3) },
                new MoneyRecordViewModels { category=(MoneyCategory)1,money=400,date=new DateTime(2016,1,4) },
            };
        }

        #endregion
    }
}