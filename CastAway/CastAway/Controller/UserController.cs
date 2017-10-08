using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CastAway.Models;
using System.Collections.Generic;
using System.Net.Http;
namespace CastAway.Controller
{
    public static class UserController
    {
        public static async Task<bool> InsertUserData(UserDetails user)
		{
            string urls = $"{Constants.BaseUrl}Name={user.FullName}&TwitterHandle={user.ScreenName}&Language={user.Language}&LocationLat={user.LocationLat}&LocationLong={user.LocationLong}&NotificationTag={user.ScreenName}&Locality={user.Locality}&NotificationTag={user.ScreenName}&Method=insert";
            try
            {
                object newOne = await APICall(urls);
                string ress = newOne as string;
                CastAway.Helpers.Settings.GeneralSettings = JsonConvert.SerializeObject(user);

				return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        public static async Task<List<UserDetails>> GetAllUsers(UserDetails user)
		{
			string urls = $"{Constants.BaseUrl}Name={user.FullName}&TwitterHandle={user.ScreenName}&Language={user.Language}&LocationLat={user.LocationLat}&LocationLong={user.LocationLong}&NotificationTag={user.ScreenName}&Locality={user.Locality}&NotificationTag={user.ScreenName}&Method=get";
			try
			{
				object newOne = await APICall(urls);
                var ress = JsonConvert.DeserializeObject<List<UserDetails>>(newOne.ToString())  ;
                return ress;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public static async Task<object> APICall(string url)
		{
            try
            {
                string urls = url;
                HttpClient webclient = new HttpClient();
                string resp = await webclient.GetStringAsync(urls);
                dynamic deserializedDynamic = JsonConvert.DeserializeObject<ApiResponse>(resp);
                if (deserializedDynamic.Code == 200 && deserializedDynamic.ResultCount > 0)
                {
                    return deserializedDynamic.Result;
                }
                else
                {
                    throw new Exception(deserializedDynamic.Description);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
    }
}
