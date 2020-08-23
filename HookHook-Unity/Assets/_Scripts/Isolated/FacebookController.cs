using System.Collections;
using System.Collections.Generic;
using PFacebook;
using UnityEngine;

public class FacebookController : MonoBehaviour
{
    public void LogIn() {
        FacebookRepository.MyFacebook.Login();
    }
    public void Share() {
        FacebookRepository.MyFacebook.Share("https://www.facebook.com/hookhookofficial", "Come play with us ^^", "Game nay hay lam anh em oi", "shorturl.at/knAKU");
    }
}
