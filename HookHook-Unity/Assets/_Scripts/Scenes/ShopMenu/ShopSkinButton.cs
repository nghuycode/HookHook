using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkinButton : MonoBehaviour
{
    public ShopSelection shopSelect;
    public void OnClick()
    {
        shopSelect.SelectSkinPanel();
    }
}
