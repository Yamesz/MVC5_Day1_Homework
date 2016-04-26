using AutoMapper;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Repositories;
using Day1Homework.Service;
using Day1Homework.Service.Dapper;
using Day1Homework.Service.EF;
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
        public ILogService logService { get; set; }

        public HomeController(
            IAccountBookService accountBookService,
            ILogService logService)
        {
            //var unitOfWork = new EFUnitOfWork();
            //this.accountBookService = new AccountBookService(unitOfWork);
            //this.logService = new LogService(unitOfWork);
            this.accountBookService = accountBookService;
            this.logService = logService;

        }

        public ActionResult Index()
        {
            if (TempData["AlertViewModel"] != null)
            {
                ViewData["AlertViewModel"] = TempData["AlertViewModel"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MoneyRecordViewModel moneyRecordViewModel)
        {
            DescriptionValidate(moneyRecordViewModel);
            if (ModelState.IsValid)
            {
                AccountBook accountBook =
                    Mapper.Map<AccountBook>(moneyRecordViewModel);

                
                try
                {
                    this.accountBookService.Save(accountBook);

                    this.logService.Save(new Log
                    {
                        AccountBookID = accountBook.Id,
                        Email = "a@a.a",
                        Name = "test"
                    });

                    //測試錯誤情況
                    if(accountBook.Amounttt == 444)
                    {
                        int a = 0;
                        int b = 1 / a;
                    }
                    
                    this.logService.Commit();
                }
                catch (Exception ex)
                {
                    TempData["AlertViewModel"] = new AlertViewModel
                    {
                        Title = "記帳失敗",
                        Msg = ex.Message,
                        Status = "error"
                    };
                    return RedirectToAction("Index");
                }

                //ModelState.Clear();
                TempData["AlertViewModel"] = new AlertViewModel
                {
                    Title = "記帳成功",
                    Msg = "持續下去",
                    Status = "success"
                };  
                return RedirectToAction("Index");
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