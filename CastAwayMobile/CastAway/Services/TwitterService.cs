﻿using System;
//using LinqToTwitter;
namespace CastAway.Services
{
    public class TwitterService
    {
		//private static TwitterContext GetTwitterContext()
		//{
		//	var auth = new XAuthAuthorizer()
		//	{
		//		CredentialStore = new InMemoryCredentialStore
		//		{
		//			ConsumerKey = "B86OgAiSUnxXYXsspdJpvWuKH",
		//			ConsumerSecret = "uyHG0czAlBuXTnjjxOv3EIGDhZ0M9mg92JexjPUqYMZRLVSotW",
		//			OAuthToken = App.User.Token,
		//			OAuthTokenSecret = App.User.TokenSecret,
		//			ScreenName = App.User.ScreenName,
		//			UserID = ulong.Parse(App.User.TwitterId)
		//		},
		//	};
		//	auth.AuthorizeAsync();

		//	var ctx = new TwitterContext(auth);
		//	return ctx;
		//}

		//public static List<Message> Search(string searchText = "xamarin")
		//{
		//	try
		//	{
		//		var ctx = GetTwitterContext();

		//		var searchResponses = (from search in ctx.Search
		//							   where search.Type == SearchType.Search
		//							   && search.Query == searchText
		//							   select search).SingleOrDefault();

		//		var tweets = from tweet in searchResponses.Statuses
		//					 select new Message
		//					 {
		//						 Value = tweet.Text,
		//						 Id = tweet.TweetIDs,
		//						 ImageUri = tweet.User.ProfileImageUrl,
		//						 UserName = tweet.User.ScreenNameResponse,
		//						 Name = tweet.User.Name,
		//						 CreatedAt = tweet.CreatedAt,
		//						 ReTweets = tweet.RetweetCount,
		//						 Favorite = tweet.FavoriteCount.Value
		//					 };

		//		return tweets.ToList();
		//	}
		//	catch (Exception ex)
		//	{
		//		ex.Message.ToString();
		//	}
		//	return new List<Message>();
		//}
        public TwitterService()
        {
        }
    }
}
