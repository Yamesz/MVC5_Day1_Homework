namespace Day1Homework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Money : DbContext
    {
        public Money()
            : base("name=Money1")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
