using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelection : MonoBehaviour
{
    SkinPanelManager skinManager;
    ShopBgManager bgManager;
    ShopRopeManager ropeManager;
    void select(ShopPanelManager panelManager)
    {
        skinManager.DeActivePanel();
        bgManager.DeActivePanel();
        ropeManager.DeActivePanel();
        panelManager.ActivePanel();
    }
}
