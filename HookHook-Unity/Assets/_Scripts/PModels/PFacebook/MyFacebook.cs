using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFacebook
{
    public class MyFacebook
    {
        public MyFacebook()
        {
            if (!FB.IsInitialized)
                FB.Init(() =>
                {
                    if (FB.IsInitialized)
                        FB.ActivateApp();
                    else
                        Debug.LogError("NO FB");
                },
                isGameShown =>
                {
                    if (!isGameShown)
                        Time.timeScale = 0;
                    else
                        Time.timeScale = 1;
                });
            else
                FB.ActivateApp();
        }

        public void Login()
        {
            var permissions = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(permissions);
        }

        public void Logout()
        {
            FB.LogOut();
        }

        public void Share(string shareLink, string title, string description, string imageLink)
        {
            FB.ShareLink(new System.Uri(shareLink), title, description, new System.Uri(imageLink));
        }

        public void FacebookGameRequest(string message, string title)
        {
            FB.AppRequest(message, title: title);
        }

        public void getFriendsPlaying()
        {
            string query = "/me/friends";
            FB.API(query, HttpMethod.GET, result =>
            {
                var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
                var friendList = (List<object>)dictionary["data"];
            });
        }
    }
}
