using System;
namespace CastAway.Models
{
    public class ApiResponse
    {
		public int Code { get; set; }
		public string Description { get; set; }
        public object Result { get; set; }
		public int ResultCount { get; set; }
    }
}
