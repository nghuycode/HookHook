using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PUser;
public class LevelManager : MonoBehaviour
{
    static public LevelManager LM;
    const int totalLevel = 27; //Total number of levels
    int userLevel; //Level user has unlocked
    int numPanel;
    int curPanel;
    GameObject[] gridObject = new GameObject[totalLevel];
    LevelGrid[] levelGrid = new LevelGrid[totalLevel];
    GameObject[] panel = new GameObject[totalLevel/9 + 1];

    public GameObject levelPanel;
    public GameObject panelPrefab;
    public GameObject gridPrefab;

    

    void Awake()
    {
        if (LM != null) GameObject.Destroy(LM);
        else LM = this;

        numPanel = (totalLevel - 1)/ 9 + 1;
        curPanel = GetUserLevel()/9;
        InstancePanel();
        for (int i = 0; i < totalLevel; i++)
        {
            GameObject lvPanel = panel[i / 9];
            InstantiateIn(ref gridObject[i], lvPanel,gridPrefab);
            levelGrid[i] = gridObject[i].GetComponent<LevelGrid>();
            SetGridInfo(i);
        }
    }

    void InstancePanel()
    {
        for (int i = 0; i < numPanel; i++)
        {
            InstantiateIn(ref panel[i], levelPanel, panelPrefab);
            panel[i].transform.localPosition = Vector3.zero;
            panel[i].name = "Panel" + i.ToString();
        }

        for (int i = 0; i < numPanel; i++)
            if (i != curPanel) panel[i].SetActive(false);
    }


    public void GoToNextPanel()
    {
        if(curPanel < numPanel - 1)
        {
            panel[curPanel].SetActive(false);
            panel[++curPanel].SetActive(true);
        }
    }

    public void GoToPrePanel()
    {
        if (curPanel > 0)
        {
            panel[curPanel].SetActive(false);
            panel[--curPanel].SetActive(true);
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

    void InstantiateIn(ref GameObject newGameobject,GameObject fatherGameobject, GameObject prefab)
    {
        newGameobject = Instantiate(prefab);
        newGameobject.transform.SetParent(fatherGameobject.transform);
    }

    int GetUserLevel()
    {
        int userLevel = UserRepository.User.Level;
        return userLevel;
    }
}
