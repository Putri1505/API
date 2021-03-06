using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Person)
                .WithOne(e => e.Account)
                .HasForeignKey<Account> (a => a.NIK);

            modelBuilder.Entity<Profiling>()
                .HasOne(pr => pr.Account)
                .WithOne(a => a.Profiling)
                .HasForeignKey<Profiling>(a => a.NIK);

            modelBuilder.Entity<Profiling>()
                .HasOne(pr => pr.Education)
                .WithMany(ed => ed.Profiling);

            modelBuilder.Entity<Education>()
                .HasOne(ed => ed.University)
                .WithMany(u => u.Education);
            //set primary key
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.NIK, ar.Roleid});

            modelBuilder.Entity<AccountRole>()
                .HasOne(a => a.Role)
                .WithMany(r => r.AccountRoles)
                .HasForeignKey(a => a.Roleid);

            modelBuilder.Entity<AccountRole>()
                .HasOne(r => r.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(r => r.NIK);


        }





    }

}
