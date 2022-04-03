using CsvHelper;
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
                    if (user.Nom.ToLower().Contains(nomInput.Text.ToLower()) || user.Prenom.ToLower().Contains(nomInput.Text.ToLower()))
                    {
                        return true;
                    }
                    return false;
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
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result.ToString() != string.Empty)
                {
                    string path = dialog.SelectedPath;
                    using var writer = new StreamWriter(path + "\\export.csv");
                    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    csv.WriteRecords(userList.ItemsSource);
                    _ = MessageBox.Show("Export sauvegardé");
                }
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
                using var reader = new StreamReader(openFileDialog.FileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var users = csv.GetRecords<User>();
                foreach (var user in users)
                {
                    UserRepo.Add(user);
                }
            }
        }
    }
}
