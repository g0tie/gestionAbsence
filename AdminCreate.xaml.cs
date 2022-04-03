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

namespace GestionAbsence
{
    /// <summary>
    /// Logique d'interaction pour AdminCreate.xaml
    /// </summary>
    public partial class AdminCreate : Window
    {
        public User user = new();
        public bool create = false;
        public AdminCreate()
        {
            InitializeComponent();
            LoadRoles();
            userForm.DataContext = user;
        }

        private void LoadRoles()
        {
            selectRole.Items.Add(new { Text = "Admin", Value = 1});
            selectRole.Items.Add(new { Text = "Formateur", Value = 2 });
            selectRole.Items.Add(new { Text = "Secrétaire", Value = 3 });
            selectRole.Items.Add(new { Text = "Apprenant", Value = 4 });
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
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

            if (user.Password == null || user.Password == "")
            {
                _ = MessageBox.Show("Veuillez saisir un mot de passe");
                return;
            }

            if (selectRole.SelectedIndex == -1)
            {
                _ = MessageBox.Show("Veuillez choisir un role");
                return;
            }
            user.RoleId = (selectRole.SelectedItem as dynamic).Value;

            UserRepo.Add(user);
            create = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
