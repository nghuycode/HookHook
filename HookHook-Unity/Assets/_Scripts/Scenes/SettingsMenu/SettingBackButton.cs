using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBackButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneSystem.SM.SettingsMenuToStartMenu();
        AudioManager.AM.Play("Button");
    }
}
