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
using System.Data.SqlClient;
using System.Data;
using orkdis;

namespace jg
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnrejButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 rw = new Window1();
            rw.Show();
            this.Close();
        }

        private void btnlogButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public void MainW()
        {
            SqlConnection s = new SqlConnection(@"Data Source=DESKTOP-853AFB5\annaw;Initial Catalog=kasyn;Integrated Security=True");

            try
            {
                if (s.State == ConnectionState.Closed)
                {
                    s.Open();
                }

                string query = "SELECT COUNT(1) FROM Users WHERE  Imie + ' ' + Nazwisko ='" + txtlog.Text + "' AND Haslo ='" + txthas.Password + "'";
                SqlCommand sc = new SqlCommand(query, s);
                sc.CommandType = CommandType.Text;
                int count = Convert.ToInt32(sc.ExecuteScalar());
                var login = txtlog.Text.Split(' ');
                string im = login[1];

                if (count == 1)
                {

                    string connectionString = @"Data Source=DESKTOP-853AFB5\annaw;Initial Catalog=kasyn;Integrated Security=True";
                    using (DatabaseContext db = new DatabaseContext(connectionString))
                    {
                        Window2 mw = new Window2();
                        mw.saldo.Text = $"Twoje saldo: + {db.Users.Where(x => x.Imie.Equals(im)).Select(x => x.Saldo).First().ToString()}";
                        mw.wintxt.Text = "Graj by wygrać";
                        mw.Show();
                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Błędne login lub hasło.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                s.Close();
            }


        }

        private void txtPesel_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

    }


}
