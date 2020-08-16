using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBackButton : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.SM.ShopMenuToStartMenu();
    }
}
