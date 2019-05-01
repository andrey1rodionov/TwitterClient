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
        TwitterService twitter;

        GetTweets getTweets;

        FileStream mediaFile = null;

        public ImageSource UserImage { get; set; }
        public int UserTweets { get; set; }
        public int UserFollowing { get; set; }
        public int UserFollowers { get; set; }
        public string UserName { get; set; }

        public MainMenu(TwitterService twitter)
        {
            InitializeComponent();
            this.twitter = twitter;
            this.getTweets = new GetTweets(this.twitter.service);
            ShowUserInfo(getTweets.GetUserInfo());
            DataContext = this;
        }

        public void HideSendTweetComponents()
        {
            SendTweetGrid.Visibility = Visibility.Hidden;
            ListBoxTweets.Visibility = Visibility.Visible;
        }

        public void ShowUserInfo(TwitterUser user)
        {
            UserImage = GetImage(user.ProfileImageUrlHttps);
            UserTweets = user.StatusesCount;
            UserFollowing = user.FriendsCount;
            UserFollowers = user.FollowersCount;
            UserName = user.Name;
        }

        public ImageSource GetImage(string path)
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri(path, UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();

            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }

            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);

            image.StreamSource = memoryStream;
            image.EndInit();

            return image;
        }

        public async void ShowTweets(IEnumerable<TwitterStatus> tweets)
        {
            if (tweets == null)
            {
                return;
            }

            foreach (var tweet in tweets)
            {
                await Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        Tweet TweetInList = new Tweet(tweet);
                        TweetInList.Retweet += getTweets.RetweetTweet;
                        //TweetInList.Retweet += this.IncreasetweetCount;
                        ListBoxTweets.Items.Add(TweetInList);
                    });
                });
            }
        }

        private void AddFileToTweet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowTweetsInLine_Click(object sender, RoutedEventArgs e)
        {
            HideSendTweetComponents();

            ListBoxTweets.Items.Clear();
            ShowTweets(getTweets.GetTweetsInLine());
        }

        private void ShowMyTweets_Click(object sender, RoutedEventArgs e)
        {
            HideSendTweetComponents();

            ListBoxTweets.Items.Clear();
            ShowTweets(getTweets.GetMyTweets());
        }

        private void ShowSendTweetComponents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendTweet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
