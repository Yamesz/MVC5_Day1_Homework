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
            //accountBookService = new AccountBookService();
            //accountBookService = new AccountBookDapperService();
            this.accountBookService = service;
        }

        public ActionResult Index()
        {
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
        #endregion
    }
}