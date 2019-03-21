using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using TweetSharp;
using TwitterClient.Pages;

namespace TwitterClient
{
    class TwitterAuthorization
    {
        ITwitterService service;

        OAuthRequestToken requestToken;

        Pages.Authorization authorization; 

        public TwitterAuthorization(string consumerKey, string consumerSecret)
        {
            service = new TwitterService(consumerKey, consumerSecret);
        }

        public TwitterAuthorization(Authorization authorization)
        {
            this.authorization = authorization;
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
    }
}
