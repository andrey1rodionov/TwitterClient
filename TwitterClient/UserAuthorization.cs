using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using TweetSharp;

namespace TwitterClient
{
    public class UserAuthorization
    {
        ITwitterService service;

        OAuthRequestToken requestToken;

        public UserAuthorization(ITwitterService service)
        {
            this.service = service;
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

        public void LoadSettings()
        {
            XDocument xDoc = XDocument.Load("../../Files/Settings.xml");
            XElement root = xDoc.Element("Settings");

            foreach (XElement xElement in root.Elements("Save").ToList())
            {
                if (xElement.Element("Theme").Value == "1")
                {
                    Uri uri = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
                    Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary() { Source = uri });
                }
                else
                {
                    Uri uri = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                    Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary() { Source = uri });
                }

                if (xElement.Element("Color").Value == "1")
                {
                    Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Cyan.xaml");
                    Application.Current.Resources.MergedDictionaries.RemoveAt(2);
                    Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });
                }

                if (xElement.Element("Color").Value == "2")
                {
                    Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml");
                    Application.Current.Resources.MergedDictionaries.RemoveAt(2);
                    Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });
                }

                if (xElement.Element("Color").Value == "3")
                {
                    Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml");
                    Application.Current.Resources.MergedDictionaries.RemoveAt(2);
                    Application.Current.Resources.MergedDictionaries.Insert(2, new ResourceDictionary() { Source = uri });
                }
            }
        }
    }
}
