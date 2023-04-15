using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;


namespace Bank.Model_CodeFirts
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Определяем класс сущности "Счет"
    public class Account
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public decimal Balance { get; set; }
        public string FullName { get; set; }
        public virtual Role Role { get; set; }
    }

    public class MCodeFirst : DbContext
    {
        // Your context has been configured to use a 'MCodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Bank.Model_CodeFirts.MCodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MCodeFirst' 
        // connection string in the application configuration file.
        //public MCodeFirst()
        //    : base("name=MCodeFirst")
        //{
        //}

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDatabase;Trusted_Connection=True;");
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