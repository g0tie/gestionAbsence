using CsvHelper;
using CsvHelper.Configuration;
using GestionAbsence.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Windows.Shapes;
using GestionAbsence.Repository;

namespace GestionAbsence
{
    /// <summary>
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            LoadUsers();
        }
        List<User> users;
        public sealed class FooMap : ClassMap<User>
        {
            public FooMap()
            {
                AutoMap(CultureInfo.InvariantCulture);
                _ = Map(m => m.Id).Ignore();
                _ = Map(m => m.Role.Id).Ignore();
                _ = Map(m => m.Role.Libelle).Ignore();

            }
        }
        public void LoadUsers()
        {
            selectRole.Items.Clear();
            selectRole.Items.Add("");
            this.users = new List<User>();
            this.users = UserRepo.GetAll();
            if (users.Any(user => user.RoleId == 1)) {
                selectRole.Items.Add(new { Text = "Admin", Value = 1 });
            }
            if (users.Any(user => user.RoleId == 2))
            {
                selectRole.Items.Add(new { Text = "Formateur", Value = 2 });
            }
            if (users.Any(user => user.RoleId == 3))
            {
                selectRole.Items.Add(new { Text = "Secrétaire", Value = 3 });
            }
            if (users.Any(user => user.RoleId == 4))
            {
                selectRole.Items.Add(new { Text = "Apprenant", Value = 4 });
            }
            userList.ItemsSource = null;
            userList.ItemsSource = this.users;
            userList.Items.Refresh();
        }

        private void SelectRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchUser();
        }

        private void NomInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchUser();
        }

        private void SearchUser()
        {
            var filteredUser = users.AsEnumerable();
            if (nomInput.Text != "")
            {
                filteredUser = filteredUser.Where((user) =>
                {
                    return user.Nom.ToLower().Contains(nomInput.Text.ToLower()) || user.Prenom.ToLower().Contains(nomInput.Text.ToLower());
                });
            }
            if (selectRole.SelectedIndex != -1 && selectRole.SelectedIndex != 0)
            {
                filteredUser = filteredUser.Where(x => x.RoleId == (selectRole.SelectedItem as dynamic).Value);
            }
            userList.ItemsSource = filteredUser;
        }

        private void OpenUpdateUserWindow_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)userList.SelectedItem;
            if (user == null)
            {
                _ = MessageBox.Show("Aucun utilisateur selectionné");
                return;
            }
            AdminUpdate updateWindow = new AdminUpdate(user) { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            _ = updateWindow.ShowDialog();
            LoadUsers();
        }

        private void OpenAddUserWindow_Click(object sender, RoutedEventArgs e)
        {
            AdminCreate createWindow = new AdminCreate { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            _ = createWindow.ShowDialog();
            if (createWindow.create)
            {
                LoadUsers();
            }
        }

        private void OpenDeleteUserWindow_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.IList users = userList.SelectedItems;
            if (users.Count == 0)
            {
                _ = MessageBox.Show("Aucun utilisateur selectionné");
                return;
            }
            string message = users.Count == 1 ? "Voulez vous vraiment supprimez cet utilisateur ?" : "Voulez vous vraiment supprimez ces utilisateurs ?";
            if (MessageBox.Show(message,"Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (User user in users)
                {
                    UserRepo.Delete(user);
                }
                LoadUsers();
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            using System.Windows.Forms.FolderBrowserDialog dialog = new();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.Cancel)
            {
                string path = dialog.SelectedPath;
                using StreamWriter writer = new(path + "\\export.csv");
                using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);
                _ = csv.Context.RegisterClassMap<FooMap>();
                csv.WriteRecords(userList.ItemsSource);
                _ = MessageBox.Show("Export sauvegardé");
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "csv files (*.csv)|*.csv"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                using StreamReader reader = new(openFileDialog.FileName);
                using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
                _ = csv.Context.RegisterClassMap<FooMap>();
                IEnumerable<User> users = csv.GetRecords<User>();
                foreach (User user in users)
                {
                    user.Role = null;
                    UserRepo.Add(user);
                }
                LoadUsers();
            }
        }
    }
}
