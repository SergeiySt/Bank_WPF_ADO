using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Linq;
using static Bank.Model.Users;

using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Bank.Model
{
     public class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Account
        {
            public int Id { get; set; }
            public int Number { get; set; }
            public decimal Amount { get; set; }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int RoleId { get; set; }
            public virtual Role Role { get; set; }
            public int AccountId { get; set; }
            public virtual Account Account { get; set; }
        }
    public class MCCodeFitrs : System.Data.Entity.DbContext
    {
        // Your context has been configured to use a 'MCCodeFitrs' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Bank.Model.MCCodeFitrs' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MCCodeFitrs' 
        // connection string in the application configuration file.
        //public MCCodeFitrs() : base("name=MCCodeFitrs")
        //{
        //}

        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<Person> Persons { get; set; }
        public MCCodeFitrs() : base("MyDbConnection")
        {
            Database.SetInitializer<System.Data.Entity.DbContext>(new CreateDatabaseIfNotExists<System.Data.Entity.DbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasRequired(p => p.Role)
                .WithMany()
                .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Person>()
                .HasRequired(p => p.Account)
                .WithMany()
                .HasForeignKey(p => p.AccountId);
        }

        protected override void Seed(MCCodeFitrs context)
        {
            // Добавляем роли
            context.Roles.AddOrUpdate(new Role { Id = 1, Name = "Администратор" });
            context.Roles.AddOrUpdate(new Role { Id = 2, Name = "Пользователь" });

            // Добавляем счета
            context.Accounts.AddOrUpdate(new Account { Id = 1, Number = 3444, Amount = 1000 });
            context.Accounts.AddOrUpdate(new Account { Id = 2, Number = 4444, Amount = 2000 });

            // Добавляем записи о ролях и счетах
            context.Persons.AddOrUpdate(new Person { Id = 1, RoleId = 1, AccountId = 1, Name = "Иванов Иван" });
            context.Persons.AddOrUpdate(new Person { Id = 2, RoleId = 2, AccountId = 2, Name = "Петров Петр" });

            base.Seed(context);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}