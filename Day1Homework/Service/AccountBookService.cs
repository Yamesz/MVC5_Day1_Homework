using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;

namespace Day1Homework.Service
{
    public class AccountBookService : IAccountBookService
    {
        private Money db = new Money();

        public IEnumerable<AccountBook> GetPageData(int page, int pageSize)
        {
            return db.AccountBook.Skip((page-1)* pageSize).Take(pageSize).ToList();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}