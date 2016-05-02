using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using Day1Homework.Repositories;
using System.Data.Entity;

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

        public IEnumerable<AccountBook> GetPageData(int pageIndex, int pageSize)
        {
            return _db.AccountBook
                    .OrderByDescending(x=>x.Dateee)
                    .Skip((pageIndex) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public AccountBook GetRecord(Guid id)
        {
            return _db.AccountBook
                    .Where(x => x.Id == id)
                    .Single();
                    
        }

        public void Edit(AccountBook accountBook)
        {
            _db.Entry(accountBook).State = EntityState.Modified;
        }

        public void Add(AccountBook accountBook)
        {
            accountBook.Id = Guid.NewGuid();
            accountBook.Remarkkk = accountBook.Remarkkk ?? string.Empty;
            _db.AccountBook.Add(accountBook);
        }

        public int GetTotalCount()
        {
            return _db.AccountBook.Select(x => x.Id).Count();
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