using Day1Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Homework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// context
        /// </summary>
        Money Context { get; set; }
        /// <summary>
        /// save change
        /// </summary>
        void Save();
    }
}
