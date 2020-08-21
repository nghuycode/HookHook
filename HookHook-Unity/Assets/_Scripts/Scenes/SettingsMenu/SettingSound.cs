using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour
{
    public Image ModelOn, ModelOff;
    public Button button;
    int isOn;//1 on,0 off

    void Awake()
    {
        isOn = PlayerPrefs.GetInt("SoundVolume");
        if (isOn == 0) TurnOff();
        else TurnOn();

    }
    public void OnClick()
    {
        if (isOn == 1) TurnOff();
        else TurnOn();
    }

    void TurnOff()
    {
        isOn = 0;
        PlayerPrefs.SetInt("SoundVolume", isOn);
        button.image.sprite = ModelOff.sprite;
        AudioManager.AM.UIThread.volume = 0;
        for (int i = 0; i < AudioManager.AM.GamePlayThread.Length; i++)
            AudioManager.AM.GamePlayThread[i].volume = 0;
    }

    void TurnOn()
    {
        isOn = 1;
        PlayerPrefs.SetInt("SoundVolume", isOn);
        button.image.sprite = ModelOn.sprite;
        AudioManager.AM.UIThread.volume = 1;
        for (int i = 0; i < AudioManager.AM.GamePlayThread.Length; i++)
            AudioManager.AM.GamePlayThread[i].volume = 0;
    }
}
