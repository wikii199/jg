using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using orkdis;

namespace jg
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-853AFB5\annaw;Initial Catalog=kasyn;Integrated Security=True";
            using (DatabaseContext db = new DatabaseContext(connectionString))
            {
                bool isCorrect = false;
                

                if(txtPesel.Text.Length != 11)
                {
                    MessageBox.Show("Pesel nieprawidłowy");
                }
                if (txtNrT.Text.Length != 9)
                {
                    MessageBox.Show("Numer telefonu nieprawidłowy");
                }
                else isCorrect = true;

                Window2 w2 = new Window2();

                if (isCorrect)
                {
                    db.Add(new User { Imie = txtImie.Text, Nazwisko = txtNazwisko.Text, Haslo = txtHaslo.Password, Pesel = txtPesel.Text, NrTel = txtNrT.Text});
                    db.SaveChanges();
                    db.Add(new Pieniadze { UserID = db.Users.Where(x => x.Pesel == txtPesel.Text).FirstOrDefault().UserID, Saldo = 100 });
                }
                w2.saldo.Text = "Twoje saldo: " + 100;
                w2.wintxt.Text = "Graj by wygrać";
                w2.Show();
                this.Close();

            }
        }
    }
}
