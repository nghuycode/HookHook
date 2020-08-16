using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Model<GameplayApp>
{
    public float Weight;
    public int SkinID;
    public bool IsSwinging, CanPlay;
    public Vector3 DefaultPosition;
    public enum Buff 
    { 
        
    };
    public enum DeBuff
    {

    };

}
