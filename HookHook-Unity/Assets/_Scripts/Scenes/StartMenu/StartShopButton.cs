using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShopButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneSystem.SM.StartMenuToShopMenu();
        AudioManager.AM.Play("Button");
    }
}
