using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AM;
    public AudioSource MusicThread, UIThread;
    public AudioSource[] GamePlayThread;
    public GameObject audioList;
    public List<Audio> audioClip;
    int cntThread;
    void Awake()
    {
        if (AM != null)
            GameObject.Destroy(AM);
        else
            AM = this;
        DontDestroyOnLoad(this);
        CheckSettings();
        GetAudio();
    }
    void GetAudio()
    {
        for (int i = 0; i < audioList.transform.childCount; i++)
            audioClip.Add(audioList.transform.GetChild(i).GetComponent<Audio>());
    }
    void CheckSettings()
    {
        if (PlayerPrefs.GetInt("SoundVolume") == 0) TurnOffSound();
        else TurnOnSound();
        if (PlayerPrefs.GetInt("MusicVolume") == 0) TurnOffMusic();
        else TurnOnMusic();

    }
    void Attach(Audio audio)
    {
        if (audio.type == Audio.AudioType.music)
        {
            if (audio.audioClip != MusicThread.clip)
            {
                MusicThread.clip = audio.audioClip;
            }
        }
        else if (audio.type == Audio.AudioType.uiSound)
        {
            if (audio.audioClip != UIThread.clip)
            {
                UIThread.clip = audio.audioClip;
            }
        }
        else if (audio.type == Audio.AudioType.gameSound)
        {
            if (audio.audioClip != GamePlayThread[cntThread].clip)
            {
                GamePlayThread[cntThread].clip = audio.audioClip;
            }
        }
    }
    public void Play(Audio audio)
    {
        Attach(audio);
        if(audio.type == Audio.AudioType.music)
        {
            MusicThread.Play();
        }
        else if (audio.type == Audio.AudioType.uiSound)
        {
            UIThread.Play();
        }
        else if (audio.type == Audio.AudioType.gameSound)
        {
            GamePlayThread[cntThread].Play();
        }
    }

    public void Play(string _name)
    {

        Audio audio;
        audio = null;
        for (int i = 0;i < audioClip.Count;i++) 
            if(audioClip[i].name == _name)
            {
                audio = audioClip[i];
                break;
            }
        if (audio == null) return;
        Attach(audio);
        if (audio.type == Audio.AudioType.music)
        {
            MusicThread.Play();
        }
        else if (audio.type == Audio.AudioType.uiSound)
        {
            UIThread.Play();
        }
        else if (audio.type == Audio.AudioType.gameSound)
        {
            GamePlayThread[cntThread].Play();
            cntThread = (cntThread + 1) % GamePlayThread.Length;
        }
    }

    void TurnOffSound()
    {
        AudioManager.AM.UIThread.volume = 0;
        for (int i = 0; i < AudioManager.AM.GamePlayThread.Length; i++)
            AudioManager.AM.GamePlayThread[i].volume = 0;
    }

    void TurnOnSound()
    {
        AudioManager.AM.UIThread.volume = 1;
        for (int i = 0; i < AudioManager.AM.GamePlayThread.Length; i++)
            AudioManager.AM.GamePlayThread[i].volume = 0;
    }

    void TurnOffMusic()
    { 
        AudioManager.AM.MusicThread.volume = 0;
    }

    void TurnOnMusic()
    {
        AudioManager.AM.MusicThread.volume = 1;
    }
}
