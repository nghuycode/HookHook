using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AM;
    public AudioSource MusicThread, UIThread, GamePlayThread;
    public Audio[] audioClip;

    void Awake()
    {
        if (AM != null)
            GameObject.Destroy(AM);
        else
            AM = this;
        DontDestroyOnLoad(this);
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
            if (audio.audioClip != GamePlayThread.clip)
            {
                GamePlayThread.clip = audio.audioClip;
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
            GamePlayThread.Play();
        }
    }
}
