using System.Net.Http;
using System;

namespace HttpApp
{
    static class Bbuu20Api
    {
        public static readonly String DOMAIN = "https://bbuu20-scripting.herokuapp.com";

        public static bool DoesUserExist(String username, String password)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/users/" + username + "/" + password).Result.IsSuccessStatusCode;
        }
        public static bool IsUserOnline(String username)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/users/" + username + "/state").Result.IsSuccessStatusCode;
        }
        public static bool IsUserAuthorized(String username)
        {
            return new HttpClient().GetAsync(DOMAIN + "/api/users/" + username + "/expires").Result.IsSuccessStatusCode;
        }
        public static void ChangeLoginStatus(String username, String password)
        {
            new HttpClient().GetAsync(DOMAIN + "/api/users/" + username + "/" + password + "/login");
        }
    }
}
