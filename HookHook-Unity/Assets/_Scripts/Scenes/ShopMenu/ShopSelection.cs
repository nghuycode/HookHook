using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PUser;
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
        ShopPanelUser.SPU.UpdateImg(ModelManager.MM.GetModel(UserRepository.User.currentSkin.Id));
    }
    public void SelectBgPanel()
    {
        Select(bgManager);
        ShopPanelUser.SPU.UpdateImg(ModelManager.MM.GetModel(UserRepository.User.currentBackground.Id));
    }
    public void SelectRopePanel()
    {
        Select(ropeManager);
        ShopPanelUser.SPU.UpdateImg(ModelManager.MM.GetModel(UserRepository.User.currentRope.Id));
    }

}
