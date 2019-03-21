using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using System.Diagnostics;
using System.Windows;
using System.IO;

namespace TwitterClient
{
    class TwitterAccount
    {
        ITwitterService service;

        public TwitterAccount(string consumerKey, string consumerSecret)
        {
            service = new TwitterService(consumerKey, consumerSecret);
        }

        public TwitterUser GetUserInfo()
        {
            return service.GetUserProfile(new GetUserProfileOptions() { IncludeEntities = false, SkipStatus = false });
        }
    }
}
