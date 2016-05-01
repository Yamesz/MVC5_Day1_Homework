using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.Service.Interface
{
    public interface ILogService : IDisposable
    {
        void Add(Log log);

        void Commit();
    }
}