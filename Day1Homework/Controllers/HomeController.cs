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
using Newtonsoft.Json;
using MvcPaging;

namespace Day1Homework.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IAccountBookService accountBookService { get; set; }
        public ILogService logService { get; set; }
        private int defaultPageSize;

        public HomeController(
            IAccountBookService accountBookService,
            ILogService logService)
        {
            //var unitOfWork = new EFUnitOfWork();
            //this.accountBookService = new AccountBookService(unitOfWork);
            //this.logService = new LogService(unitOfWork);
            this.accountBookService = accountBookService;
            this.logService = logService;
            this.defaultPageSize = 20;

        }

        public ActionResult Index()
        {
            if (Request.Cookies["AlertViewModel"] != null)
            {
                HttpCookie alertViewModelCookie = Request.Cookies["AlertViewModel"];
                ViewData["AlertViewModel"] = 
                    JsonConvert.DeserializeObject<AlertViewModel>(alertViewModelCookie.Value);
                alertViewModelCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(alertViewModelCookie);
            }
            return View();
        }

        public ActionResult add()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add([Bind(Exclude= "accountBookID")] MoneyRecordViewModel moneyRecordViewModel)
        {
            DescriptionValidate(moneyRecordViewModel);
            if (ModelState.IsValid)
            {
                AccountBook accountBook =
                    Mapper.Map<AccountBook>(moneyRecordViewModel);
                try
                {
                    this.accountBookService.Add(accountBook);

                    this.logService.Add(new Log
                    {
                        AccountBookID = accountBook.Id,
                        Email = "a@a.a",
                        Name = "test edit"
                    });

                    //測試錯誤情況
                    if(accountBook.Amounttt == 444)
                    {
                        int a = 0;
                        int b = 1 / a;
                    }
                    
                    this.logService.Commit();
                    HttpCookie cookie = new HttpCookie("AlertViewModel");
                    cookie.Value = JsonConvert.SerializeObject(new AlertViewModel
                    {
                        Title = "記帳成功",
                        Msg = "持續下去",
                        Status = "success"
                    });
                    Response.Cookies.Add(cookie);
                   
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["AlertViewModel"] = new AlertViewModel
                    {
                        Title = "記帳失敗",
                        Msg = ex.Message,
                        Status = "error"
                    };
                }
            }
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult MoneyRecordList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            int Skip = currentPageIndex * defaultPageSize;
            var totalCount = accountBookService.GetTotalCount();
            var model = accountBookService.GetPageData(currentPageIndex, defaultPageSize);
            List<MoneyRecordViewModel> moneyRecordList =
                Mapper.Map<List<MoneyRecordViewModel>>(model);
            ViewData.Model = moneyRecordList.ToPagedList(currentPageIndex, defaultPageSize, totalCount);
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region private 方法
        private void DescriptionValidate(MoneyRecordViewModel moneyRecordViewModel)
        {
            var descriptionLength = string.IsNullOrWhiteSpace(moneyRecordViewModel.description)
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