using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using Day1Homework.Repositories;

namespace Day1Homework.Service
{
    public class AccountBookService : IAccountBookService
    {
        private Money _db;
        private readonly IUnitOfWork _unitOfWork;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._db = this._unitOfWork.Context;
        }

        public IEnumerable<AccountBook> GetPageData(int page, int pageSize)
        {
            return _db.AccountBook
                    .OrderByDescending(x=>x.Dateee)
                    .Skip((page-1)* pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public void Add(AccountBook accountBook)
        {
            accountBook.Id = Guid.NewGuid();
            accountBook.Remarkkk = accountBook.Remarkkk ?? string.Empty;
            _db.AccountBook.Add(accountBook);
        }

        public void Commit()
        {
            _unitOfWork.Save();
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
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        
    }
}