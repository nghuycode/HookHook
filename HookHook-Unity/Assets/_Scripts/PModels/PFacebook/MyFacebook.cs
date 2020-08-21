using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFacebook
{
    public class MyFacebook
    {
        List<string> permissions = new List<string>() { "public_profile", "email"};
        public MyFacebook()
        {
            if (!FB.IsInitialized)
                FB.Init(() =>
                {
                    if (FB.IsInitialized)
                        FB.ActivateApp();
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
                Debug.Log(result.RawResult);
                var friendList = (List<object>)dictionary["data"];
            });
        }
    }
}
