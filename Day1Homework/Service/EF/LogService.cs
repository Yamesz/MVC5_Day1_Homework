using Day1Homework.Models;
using Day1Homework.Repositories;
using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.Service.EF
{
    public class LogService: ILogService
    {
        private Money _db;
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._db = this._unitOfWork.Context;
        }

        public void Add(Log log)
        {
            _db.Log.Add(log);
            
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