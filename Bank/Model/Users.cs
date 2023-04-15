using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    internal class Users
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
    }
}
