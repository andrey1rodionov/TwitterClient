﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using TweetSharp;

namespace TwitterClient
{
    public class TwitterService
    {
        ITwitterService service;

        OAuthRequestToken requestToken;

        public TwitterService(string consumerKey, string consumerSecret)
        {
            service = new TweetSharp.TwitterService(consumerKey, consumerSecret);
        }

        public TwitterUser GetUserInfo()
        {
            return service.GetUserProfile(new GetUserProfileOptions() { IncludeEntities = false, SkipStatus = false });
        }

        public void PreAuthorization()
        {
            requestToken = service.GetRequestToken();
            Uri uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());
        }

        public void VerifyAuthorization(string verifier)
        {
            OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);
            service.AuthenticateWith(access.Token, access.TokenSecret);
        }

        public bool CheackAuthorization()
        {
            if (service.GetAccountSettings() == null)
            {
                MessageBox.Show("Ошибка авторизации!");              
                return false;
            }
            else
                return true;
        }

        public void RetweetTweet(long TweetId)
        {
            service.Retweet(new RetweetOptions
            {
                Id = TweetId
            });
        }

        public IEnumerable<TwitterStatus> GetTweetsInLine()
        {
            return service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
        }

        public IEnumerable<TwitterStatus> GetMyTweets()
        {
            return service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions());
        }
    }
}
