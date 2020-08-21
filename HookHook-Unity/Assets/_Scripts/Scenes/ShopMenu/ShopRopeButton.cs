using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRopeButton : MonoBehaviour
{
    public ShopSelection shopSelection;
    public void OnClick()
    {
        shopSelection.SelectRopePanel();
        AudioManager.AM.Play("Button");
    }
}
