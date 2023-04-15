using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly MyDbContext _context;
        private ObservableCollection<Account> _accounts;
        private Account _selectedAccount;

        public MainViewModel()
        {
            _context = new MyDbContext();
            _accounts = new ObservableCollection<Account>(_context.Accounts.Include(a => a.Role).ToList());
        }

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }

        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }

        public void AddAccount()
        {
            var account = new Account
            {
                RoleId = 1,
                Balance = 0,
                FullName = "New User"
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
            Accounts.Add(account);
            SelectedAccount = account;
        }

        public void DeleteAccount()
        {
            if (SelectedAccount == null) return;
            _context.Accounts.Remove(SelectedAccount);
            _context.SaveChanges();
            Accounts.Remove(SelectedAccount);
        }
    }
}
}
