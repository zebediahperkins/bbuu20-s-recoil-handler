using System.Net.Http;
using System;

namespace HttpApp
{
    static class Bbuu20Api
    {
        public static readonly String DOMAIN = "https://bbuu20-scripting.herokuapp.com";

        public static bool DoesUserExist(String username, String password)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/login/?username=" + username + "&password=" + password).Result.IsSuccessStatusCode;
        }
        public static bool IsUserOnline(String username)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/status/?username=" + username).Result.IsSuccessStatusCode;
        }
        public static bool IsUserAuthorized(String username)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/expires/?username=" + username).Result.IsSuccessStatusCode;
        }
        public static void ChangeLoginStatus(String username, String password)
        {
            new HttpClient().GetAsync(DOMAIN + "/api/changeStatus/?username=" + username + "&password=" + password);
        }
    }
}