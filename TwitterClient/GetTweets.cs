using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterClient
{
    public class GetTweets
    {
        ITwitterService service;

        public GetTweets(ITwitterService service)
        {
            this.service = service;
        }

        public TwitterUser GetUserInfo()
        {
            return service.GetUserProfile(new GetUserProfileOptions() { IncludeEntities = false, SkipStatus = false });
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
