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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
namespace GestionAbsence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using GestionAbsenceDbContext db = new();
            var roles = db.Users.Include(i => i.Role).ToList();
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            var Username = login.Text;
            var Password = password.Password;

            using (GestionAbsenceDbContext context = new GestionAbsenceDbContext())
            {
                bool userfound = context.Users.Any(user => user.Mail == Username && user.Password == Password);

                if (userfound)
                {
                    new Admin().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("nom d'utilisateur ou mdp incorrecte");
                }
            }
        }
    }
}
