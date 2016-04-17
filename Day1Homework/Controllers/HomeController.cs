using AutoMapper;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Service;
using Day1Homework.Service.Interface;
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
        private IAccountBookService accountBookService;

        public HomeController()
        {
            accountBookService = new AccountBookService();
        }
        public ActionResult Index()
        {
            ViewBag.CategoryList = CategoryGet();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyRecordList()
        {
            var model = accountBookService.GetPageData(1, 5);
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
        #endregion
    }
}