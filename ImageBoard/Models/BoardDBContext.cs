using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace ImageBoard.Models
{
    public class BoardDBContext: DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BoardDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ImageBoardDB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().HasData(
                new Board[]
                {
                    new Board{Id=1, Name="Бред", ShortName="b"},
                    new Board{Id=2, Name="Программирование", ShortName="pr"},
                    new Board{Id=3, Name="Работа и карьера", ShortName="wrk"},
                    new Board{Id=4, Name="Общение", ShortName="soc"}
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
