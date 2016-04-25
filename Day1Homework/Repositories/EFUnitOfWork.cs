using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day1Homework.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public Money Context { get; set; }

        public EFUnitOfWork()
        {
            Context = new Money();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}