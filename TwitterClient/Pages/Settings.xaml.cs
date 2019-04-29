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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private int check = 0;

        public Settings()
        {
            InitializeComponent();
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary() { Source = uri });
            this.Close();
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary() { Source = uri });
            this.Close();
        }

        private void Cyan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            check = 1;

            Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Cyan.xaml");
            Application.Current.Resources.MergedDictionaries.RemoveAt(2);
            Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });

            Cyan.Source = new BitmapImage(new Uri("/Images/CyanWithLine.png", UriKind.Relative));

            if (check == 1)
            {
                DeepPurple.Source = new BitmapImage(new Uri("/Images/DeepPurple.png", UriKind.Relative));
                Teal.Source = new BitmapImage(new Uri("/Images/Teal.png", UriKind.Relative));
            }
        }

        private void DeepPurple_MouseDown(object sender, MouseButtonEventArgs e)
        {
            check = 2;

            Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml");
            Application.Current.Resources.MergedDictionaries.RemoveAt(2);
            Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });

            DeepPurple.Source = new BitmapImage(new Uri("/Images/DeepPurpleWithLine.png", UriKind.Relative));

            if (check == 2)
            {
                Cyan.Source = new BitmapImage(new Uri("/Images/Cyan.png", UriKind.Relative));
                Teal.Source = new BitmapImage(new Uri("/Images/Teal.png", UriKind.Relative));
            }
        }

        private void Teal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            check = 3;

            Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml");
            Application.Current.Resources.MergedDictionaries.RemoveAt(2);
            Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });

            Teal.Source = new BitmapImage(new Uri("/Images/TealWithLine.png", UriKind.Relative));

            if (check == 3)
            {
                Cyan.Source = new BitmapImage(new Uri("/Images/Cyan.png", UriKind.Relative));
                DeepPurple.Source = new BitmapImage(new Uri("/Images/DeepPurple.png", UriKind.Relative));
            }
        }
    }
}
