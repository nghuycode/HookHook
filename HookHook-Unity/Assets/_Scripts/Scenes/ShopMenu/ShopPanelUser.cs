using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PItem;
using UnityEngine.UI;

public class ShopPanelUser : MonoBehaviour
{
    static public ShopPanelUser SPU;
    public Image userImg;

    void Awake()
    {
        if (SPU != null)
            GameObject.Destroy(SPU);
        else
            SPU = this;
       
    }
    public void UpdateImg(Image img)
    {
        userImg.sprite = img.sprite;        
    }
}
