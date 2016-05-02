﻿using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.Service.Interface
{
    public interface IAccountBookService: IDisposable
    {
        IEnumerable<AccountBook> GetPageData(int pageIndex,int pageSize);

        void Add(AccountBook accountBook);

        void Commit();

        AccountBook GetRecord(Guid id);

        void Edit(AccountBook accountBook);

        int GetTotalCount();
    }
}