using PUser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AM;
    public AudioSource MusicThread, UIThread;
    public AudioSource[] GamePlayThread;
    public GameObject audioList;
    public List<Audio> audioClip;
    int cntThread = 0;
    void Awake()
    {
        if (AM != null)
            GameObject.Destroy(AM);
        else
            AM = this;
        //CheckInstanceSettings();
        //CheckSettings();
        GetAudio();
    }
    void GetAudio()
    {
        for (int i = 0; i < audioList.transform.childCount; i++)
            audioClip.Add(audioList.transform.GetChild(i).GetComponent<Audio>());
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

    public void TurnOffSound()
    {

    }

    public void TurnOnSound()
    {
        
    }

    public void TurnOffMusic()
    {

    }

    public void TurnOnMusic()
    {
        
    }
}
