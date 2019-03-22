using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using TweetSharp;

namespace TwitterClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        TwitterAccount twitter;

        FileStream mediaFile = null;

        public ImageSource UserImage { get; set; }
        public int UserTweets { get; set; }
        public int UserFriends { get; set; }
        public string UserName { get; set; }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void AddFileToTweet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowTweetsInLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowMyTweets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowSendTweetComponents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendTweet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
