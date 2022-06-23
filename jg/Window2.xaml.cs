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

namespace jg
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        
        private void grabbutButton_Click(object sender, RoutedEventArgs e)
        {
            int cashAmount = int.Parse(wintxt.Text);
            if (cashAmount > 0)
            {
                MessageBox.Show("Gratulacje, wygrałeś " + cashAmount + " zł");
            }
           


        }

      

        private void wintxt1(object sender, ContextMenuEventArgs e)
        {

        }
    }
    
}
