using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    const int totalLevel = 9; //Total number of levels
    int userLevel; //Level user has unlocked

    GameObject[] gridObject = new GameObject[totalLevel];
    LevelGrid[] levelGrid = new LevelGrid[totalLevel];
    GameObject levelPanel;
    public GameObject gridPrefab;

    

    void Awake()
    {
        levelPanel = GameObject.Find("LevelPanel");
        for (int i = 0; i < totalLevel; i++)
        {
            InstantiateIn(ref gridObject[i], levelPanel);
            levelGrid[i] = gridObject[i].GetComponent<LevelGrid>();
            SetGridInfo(i);
        }

    }

    void OnEnable()
    {
        userLevel = GetUserLevel();
        GridsInstantiate();
    }

 

    void GridsInstantiate()
    {
        


        for (int i = 0; i < userLevel; i++)
            levelGrid[i].UnlockLevel();
    }

    void SetGridInfo(int id)
    {
        gridObject[id].name = "Grid" + id.ToString();
        levelGrid[id].gridID = id;
    }

    void InstantiateIn(ref GameObject newGameobject,GameObject fatherGameobject)
    {
        newGameobject = Instantiate(gridPrefab);
        newGameobject.transform.parent = fatherGameobject.transform;
    }

    int GetUserLevel()
    {
        int userLevel = 0;//Recieved from User
        return userLevel;
    }
}
