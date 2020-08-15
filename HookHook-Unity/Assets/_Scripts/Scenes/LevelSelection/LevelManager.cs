using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    const int totalNum = 9; //Total number of levels
    int userLevel; //Level user has unlocked

    GameObject[] gridObject = new GameObject[totalNum];
    LevelGrid[] levelGrid = new LevelGrid[totalNum];
    GameObject levelPanel;
    public GameObject gridPrefab;

    

    void Awake()
    {
        levelPanel = GameObject.Find("LevelPanel");
        userLevel = GetUserLevel();
    }

    void Start()
    {
        GridsInstantiate();

    }
    void GridsInstantiate()
    {
        for (int i = 0; i < totalNum; i++)
        {
            InstantiateIn(ref gridObject[i], levelPanel);
            levelGrid[i] = gridObject[i].GetComponent<LevelGrid>();
            SetGridInfo(i);
        }

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
        int userLevel = 3;//Recieved from User
        return userLevel;
    }
}
