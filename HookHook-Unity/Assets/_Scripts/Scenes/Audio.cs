using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio: MonoBehaviour
{
    public AudioClip audioClip;
    public string name;
    public enum AudioType { music, uiSound, gameSound }
    public AudioType type;



}
