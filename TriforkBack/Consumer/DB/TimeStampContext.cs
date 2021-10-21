using Microsoft.EntityFrameworkCore;
using System;

namespace Consumer.DB
{
    public class TimestampContext : DbContext
    {
        public DbSet<Timestamp> Timestamps { get; set; }

        //https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,5433;Database=triforkDB;User Id=sa;Password=Trifork2021");
    }
}
