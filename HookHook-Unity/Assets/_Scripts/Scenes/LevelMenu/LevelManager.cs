using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PUser;
public class LevelManager : MonoBehaviour
{
    const int totalLevel = 9; //Total number of levels
    int userLevel; //Level user has unlocked

    GameObject[] gridObject = new GameObject[totalLevel];
    LevelGrid[] levelGrid = new LevelGrid[totalLevel];
    public GameObject levelPanel;
    public GameObject gridPrefab;

    

    void Awake()
    {
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
        for (int i = 0; i <= userLevel; i++)
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
        newGameobject.transform.SetParent(fatherGameobject.transform);
    }

    int GetUserLevel()
    {
        int userLevel = UserRepository.User.Level;
        return userLevel;
    }
}
