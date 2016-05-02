using Day1Homework.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Day1Homework.Service.Dapper
{
    public class AccountBookDapperService : IAccountBookService
    {
        private string ConnectionString;
        public AccountBookDapperService()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Money"].ConnectionString;
        }
 
        public IEnumerable<AccountBook> GetPageData(int page, int pageSize)
        {
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                var sqlStatement = @"
                        SELECT [t1].[Id], [t1].[Categoryyy], [t1].[Amounttt], [t1].[Dateee], [t1].[Remarkkk]
                        FROM (
                            SELECT ROW_NUMBER() OVER (ORDER BY [t0].[Amounttt] DESC) AS [ROW_NUMBER], [t0].[Id], [t0].[Categoryyy], [t0].[Amounttt], [t0].[Dateee], [t0].[Remarkkk]
                            FROM [AccountBook] AS [t0]
                            ) AS [t1]
                        WHERE [t1].[ROW_NUMBER] BETWEEN @skip + 1 AND @skip + @Take
                        ORDER BY [t1].[ROW_NUMBER]
                    ";
                var result = conn.Query<AccountBook>(
                    sqlStatement,
                    new
                    {
                        skip = (page-1) * pageSize,
                        Take = pageSize
                    });

                return result;
            }
        }

        public void Commit()
        {
            //_unitOfWork.Save();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(AccountBook accountBook)
        {
            throw new NotImplementedException();
        }

        public AccountBook GetRecord(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(AccountBook accountBook)
        {
            throw new NotImplementedException();
        }
    }
}