using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Day1Homework.CustomResults
{
    public class RssActionResult : ActionResult
    {
        private readonly SyndicationFeed feed;

        public RssActionResult()
        {
        }

        public RssActionResult(SyndicationFeed feed)
        {
            this.feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";
            var formatter = new Rss20FeedFormatter(feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                formatter.WriteTo(writer);
            }
        }
    }
}