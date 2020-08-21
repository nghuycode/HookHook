using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AM;
    public AudioSource MusicThread, UIThread;
    public AudioSource[] GamePlayThread;
    public List<Audio> audioClip;
    int cntThread;
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

    public void Play(int id)
    {
        Audio audio = audioClip[id];
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
}
