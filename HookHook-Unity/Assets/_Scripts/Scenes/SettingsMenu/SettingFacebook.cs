using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PFacebook;
public class SettingFacebook : MonoBehaviour
{
    public void OnClick()
    {
        //FacebookRepository.MyFacebook.Login();
        FacebookRepository.MyFacebook.Share("https://www.facebook.com/hookhookofficial", "Come play with us ^^", "Game nay hay lam anh em oi", "https://shorturl.at/knAKU");
    }
}
