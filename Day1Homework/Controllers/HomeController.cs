using AutoMapper;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Service;
using Day1Homework.Service.Dapper;
using Day1Homework.Service.Interface;
using Day1Homework.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public IAccountBookService accountBookService { get; set; }

        public HomeController(IAccountBookService service)
        {
            this.accountBookService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MoneyRecordViewModel moneyRecordViewModel)
        {
            DescriptionValidate(moneyRecordViewModel);
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyRecordList()
        {
            var model = accountBookService.GetPageData(1, 5);
            List<MoneyRecordViewModel> moneyRecordList =
                Mapper.Map<List<MoneyRecordViewModel>>(model);

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
        private void DescriptionValidate(MoneyRecordViewModel moneyRecordViewModel)
        {
            var descriptionLength = moneyRecordViewModel.description == null
                                    ? 0
                                    : moneyRecordViewModel.description.Length;

            if (descriptionLength > 100)
            {
                ModelState.AddModelError("description",
                    string.Format("您輸入{0}字，不能超過100個字", moneyRecordViewModel.description.Length));
            }
        }
        #endregion
    }
}