using Day1Homework.CustomResults;
using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class FeedController : Controller
    {
        public IAccountBookService accountBookService { get; set; }

        public FeedController(
            IAccountBookService accountBookService)
        {
            //var unitOfWork = new EFUnitOfWork();
            //this.accountBookService = new AccountBookService(unitOfWork);
            //this.logService = new LogService(unitOfWork);
            this.accountBookService = accountBookService;
        }

        public ActionResult Index()
        {
            var feed = GetFeedData();
            return new RssActionResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            var hostUrl = string.Format("{0}://{1}",
                Request.Url.Scheme,
                Request.Headers["host"]);

            var feed = new SyndicationFeed(
                "skilltree",
                "This is a feed from ASP.NET MVC - Rss Feed Sample",
                new Uri(string.Concat(hostUrl, "/Rss/")));

            var items = new List<SyndicationItem>();

            var list = this.accountBookService.GetPageData(1, 100);

            foreach (var p in list)
            {
                var item = new SyndicationItem(
                    title: string.Concat(p.Dateee),
                    content: string.Format("Amounttt: {0}, Remarkkk: {1}",
                                    p.Amounttt,
                                    p.Remarkkk),
                    itemAlternateLink: new Uri(string.Concat(hostUrl, "/skilltree/money/Edit/", p.Id)),
                    id: "ID",
                    lastUpdatedTime: DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
    }
}