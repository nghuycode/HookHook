using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGrid : MonoBehaviour
{
    public int gridID;
    public bool isUnlock;
    public Text levelText;
    public LevelGrid(int _gridID,bool _isUnlock)
    {
        gridID = _gridID;
        isUnlock = _isUnlock;
    }


    public void OnClick()
    {
        PlayerPrefs.SetInt("CurrentLevel", gridID);
        AudioManager.AM.Play("Button");
        SceneSystem.SM.LevelMenuToGameMenu();
    }

    public void UnlockLevel()
    {
        levelText.text = (gridID + 1).ToString();
        isUnlock = true;
        this.GetComponent<Button>().enabled = true;
        this.gameObject.GetComponent<Image>().sprite = GameObject.Find("GridActiveModel").GetComponent<Image>().sprite;
    }

}
