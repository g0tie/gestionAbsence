using GestionAbsence.Models;
using System;
using System.Collections.Generic;
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
using GestionAbsence.Services;
namespace GestionAbsence
{
    /// <summary>
    /// Logique d'interaction pour AdminUpdate.xaml
    /// </summary>
    public partial class AdminUpdate : Window
    {
        public User user;
        public bool update = false;
        public AdminUpdate(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadRoles();
            userForm.DataContext = user;
            selectRole.SelectedItem = new { Text = user.Role.Libelle, Value = user.Role.Id };
        }
        private void LoadRoles()
        {
            _ = selectRole.Items.Add(new { Text = "Admin", Value = 1 });
            _ = selectRole.Items.Add(new { Text = "Formateur", Value = 2 });
            _ = selectRole.Items.Add(new { Text = "Secretaire", Value = 3 });
            _ = selectRole.Items.Add(new { Text = "Apprenant", Value = 4 });
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (user.Nom == null || user.Nom == "")
            {
                _ = MessageBox.Show("Veuillez saisir un nom");
                return;
            }
            if (user.Prenom == null || user.Prenom == "")
            {
                _ = MessageBox.Show("Veuillez saisir un prénom");
                return;
            }

            if (user.Mail == null || user.Mail == "")
            {
                _ = MessageBox.Show("Veuillez saisir une adresse mail");
                return;
            }
            if (passwordInput.Text != null || passwordInput.Text != "")
            {
                user.Password = BcryptService.HashPassword(passwordInput.Text);
            }

            user.RoleId = (selectRole.SelectedItem as dynamic).Value;
            user.Role = null;
            UserRepo.Update(user);
            update = true;
            Close();

        }
    }
}
