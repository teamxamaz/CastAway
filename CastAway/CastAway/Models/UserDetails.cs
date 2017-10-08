using System;
namespace CastAway.Models
{
	public class UserDetails
	{
		public string TwitterId { get; set; }
		public string Name { get; set; }
		public string ScreenName { get; set; }
		public string Token { get; set; }
		public string TokenSecret { get; set; }

        public string FullName { get; set; }
        public string Language { get; set; }
        public string LocationLat { get; set; }
        public string LocationLong { get; set; }
        public string NotificationTag { get; set; }
        public string Locality { get; set; }

		public bool IsAuthenticated
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Token);
			}
		}
	}
}
