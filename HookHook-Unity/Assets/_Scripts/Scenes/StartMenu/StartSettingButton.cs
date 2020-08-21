using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSettingButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneSystem.SM.StartMenuToSettingsMenu();
        AudioManager.AM.Play("Button");
    }
}
