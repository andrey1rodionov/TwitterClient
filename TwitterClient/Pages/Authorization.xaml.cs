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

namespace TwitterClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        TwitterAuthorization twitter;

        public Authorization()
        {
            InitializeComponent();
            twitter = new TwitterAuthorization("LunW98nTNR2EnAaJLuVXvZZAY", 
                "LQXZ4JgwJn07097PXv6MHEmreVXz943yZbBXYJTM0IVPz5ZsOA");
        }

        private void SendPin_Click(object sender, RoutedEventArgs e)
        {
            twitter.VerifyAuthorization(PinTextBox.Text);

            if (twitter.CheackAuthorization())
            {
                MessageBox.Show("Авторизация прошла успешно!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            twitter.PreAuthorization();
        }
    }
}
