using AutoMapper;
using Day1Homework.CustomAttribute;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Service.Interface;
using Day1Homework.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Areas.skilltree.Controllers
{
    [AdminAuthorize]
    public class MoneyController : Controller
    {
        private IAccountBookService accountBookService { get; set; }
        private ILogService logService { get; set; }
        private int defaultPageSize;

        public MoneyController(
            IAccountBookService accountBookService,
            ILogService logService)
        {
            //var unitOfWork = new EFUnitOfWork();
            //this.accountBookService = new AccountBookService(unitOfWork);
            //this.logService = new LogService(unitOfWork);
            this.accountBookService = accountBookService;
            this.logService = logService;
            this.defaultPageSize = 50;
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
        
        public ActionResult Edit(Guid id)
        {
            var model = accountBookService.GetRecord(id);
            MoneyRecordViewModel moneyRecord =
                Mapper.Map<MoneyRecordViewModel>(model);
            return View(moneyRecord);
        }

        [HttpPost]
        public ActionResult Edit(MoneyRecordViewModel moneyRecordViewModel)
        {
            DescriptionValidate(moneyRecordViewModel);
            if (ModelState.IsValid)
            {
                AccountBook accountBook =
                    Mapper.Map<AccountBook>(moneyRecordViewModel);
                try
                {
                    this.accountBookService.Edit(accountBook);

                    this.logService.Add(new Log
                    {
                        AccountBookID = accountBook.Id,
                        Email = "a@a.a",
                        Name = "test"
                    });

                    //測試錯誤情況
                    if (accountBook.Amounttt == 444)
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
            return View();
        }

        [ChildActionOnly]
        public ActionResult AdminMoneyRecordList(int? page)
        {
            var model = accountBookService.GetPageData(page, defaultPageSize);
            var viewModel = model.ToMappedPagedList<AccountBook, MoneyRecordViewModel>();
            ViewData.Model = viewModel;
            return View("MoneyRecordList");
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