using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelCodeFirts db;
        public MainWindow()
        {
            
            InitializeComponent();

           // usersGrid.SelectionUnit = DataGridSelectionUnit.FullRow;
            db = new ModelCodeFirts();

            if (!db.Users.Any())
            {
                Role bizRole = new Role { RoleName = "Бізнесмен" };
                Role fhizRole = new Role { RoleName = "Фізична особа" };
                Role yurRle = new Role { RoleName = "Юридична особа" };
                db.Roles.Add(bizRole);
                db.Roles.Add(fhizRole);
                db.Roles.Add(yurRle);
                db.SaveChanges();

                db.Users.Add(new Users { Number = 123456789, Amount = 500000, PIB = "John Doe", Role = bizRole });
                db.Users.Add(new Users { Number = 987654321, Amount = 120000, PIB = "Jane Smith", Role = fhizRole });
                db.Users.Add(new Users { Number = 566675455, Amount = 300000, PIB = "Ігор Петрович", Role = yurRle });
                db.Users.Add(new Users { Number = 754454533, Amount = 45000, PIB = "Світлана Река", Role = yurRle });
                db.Users.Add(new Users { Number = 534535344, Amount = 456777, PIB = "Володимир Тканов", Role = yurRle });
                db.Users.Add(new Users { Number = 564562344, Amount = 800000, PIB = "Ірина Река", Role = bizRole });
                db.Users.Add(new Users { Number = 754345653, Amount = 870000, PIB = "Жора Кириленко", Role = bizRole });
                db.Users.Add(new Users { Number = 467434232, Amount = 70000, PIB = "Юрій Вікторович", Role = fhizRole });
                db.SaveChanges();
            }

            db.Users.Include(u => u.Role).Load();
            usersGrid.ItemsSource = db.Users.Local.ToBindingList();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            usersGrid.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < usersGrid.SelectedItems.Count; i++)
                {
                    Users users = usersGrid.SelectedItems[i] as Users;
                    if (users != null)
                    {
                        db.Users.Remove(users);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
