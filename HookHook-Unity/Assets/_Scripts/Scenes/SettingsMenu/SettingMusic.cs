using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMusic: MonoBehaviour
{
    public Image ModelOn, ModelOff;
    public Button button;
    int isOn;//1 on,-1 off

    void Awake()
    {
        isOn = PlayerPrefs.GetInt("MusicVolume");
        if (isOn == -1) TurnOff();
        else TurnOn();
    }
    public void OnClick()
    {
       
        if (isOn == 1) TurnOff();
        else TurnOn();
    }

    void TurnOff()
    {
        isOn = -1;
        PlayerPrefs.SetInt("MusicVolume", isOn);
        button.image.sprite = ModelOff.sprite;
        AudioManager.AM.TurnOffMusic();
    }

    void TurnOn()
    {
        isOn = 1;
        PlayerPrefs.SetInt("MusicVolume", isOn);
        button.image.sprite = ModelOn.sprite;
        AudioManager.AM.TurnOnMusic();
    }
}
