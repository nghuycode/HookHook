using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelection : MonoBehaviour
{
    public SkinPanelManager skinManager;
    public ShopBgManager bgManager;
    public ShopRopeManager ropeManager;
    

    void Select(ShopPanelManager panelManager)
    {
        skinManager.DeActivePanel();
        bgManager.DeActivePanel();
        ropeManager.DeActivePanel();
        panelManager.ActivePanel();
    }
    public void SelectSkinPanel()
    {
        Select(skinManager);
    }
    public void SelectBgPanel()
    {
        Select(bgManager);
    }
    public void SelectRopePanel()
    {
        Select(ropeManager);
    }

}
