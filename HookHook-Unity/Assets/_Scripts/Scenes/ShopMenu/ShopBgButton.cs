using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBgButton : MonoBehaviour
{
    public ShopSelection shopSelect;
    public void OnClick()
    {
        shopSelect.SelectBgPanel();
        AudioManager.AM.Play("Button");
    }
}
