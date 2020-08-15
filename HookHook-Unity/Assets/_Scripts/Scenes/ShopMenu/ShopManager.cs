using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    const int totalNum = 9; //Total number of items in shop

    GameObject[] gridObject = new GameObject[totalNum];
    ShopGrid[] shopGrid = new ShopGrid[totalNum];
    GameObject shopPanel;
    public GameObject gridPrefab;



    void Awake()
    {
        shopPanel = GameObject.Find("ShopPanel");
        for (int i = 0; i < totalNum; i++)
        {
            InstantiateIn(ref gridObject[i], shopPanel);
            shopGrid[i] = gridObject[i].GetComponent<ShopGrid>();
            SetGridInfo(i);
        }

    }

    void OnEnable()
    {
 
        GridsInstantiate();
    }



    void GridsInstantiate()
    {

    }

    void SetGridInfo(int id)
    {
        gridObject[id].name = "Grid" + id.ToString();
        shopGrid[id].gridID = id;
    }

    void InstantiateIn(ref GameObject newGameobject, GameObject fatherGameobject)
    {
        newGameobject = Instantiate(gridPrefab);
        newGameobject.transform.parent = fatherGameobject.transform;
    }

    int GetShopItemNumber()
    {
        int userLevel = 3;//Recieved from User
        return userLevel;
    }
}
