using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGrid : MonoBehaviour
{
    public int gridID;
    public bool isUnlock;
    
    public LevelGrid(int _gridID,bool _isUnlock)
    {
        gridID = _gridID;
        isUnlock = _isUnlock;
    }


    public void OnClick()
    {
        Debug.Log(gridID);
    }

    public void UnlockLevel()
    {
        isUnlock = true;
        this.GetComponent<Button>().enabled = true;
        this.gameObject.GetComponent<Image>().sprite = GameObject.Find("GridActiveModel").GetComponent<Image>().sprite;
    }

}
