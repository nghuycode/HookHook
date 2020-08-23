using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

using PFacebook;
public class SettingFacebook : MonoBehaviour
{
    private void Awake() {
        if (!FB.IsInitialized)
            FB.Init();
    }
    public void OnClick()
    {
        //FacebookRepository.MyFacebook.Login();
        FacebookRepository.MyFacebook.Share("https://www.facebook.com/hookhookofficial", "Come play with us ^^", "Game nay hay lam anh em oi", "https://shorturl.at/knAKU");
    }
}
