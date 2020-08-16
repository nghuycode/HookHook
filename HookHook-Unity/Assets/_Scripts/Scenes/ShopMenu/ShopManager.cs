using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PItem;
using PShop;
using PUser;
using PModels;
public class ShopManager : MonoBehaviour
{
    int ToTalItems; //Total number of items in shop
    public int currentItem;
    public List<GameObject> gridObject;
    public List<ShopGrid> shopGrid;
    GameObject shopPanel;
    public GameObject gridPrefab;


    void Awake()
    {
        //ToTalItems = DataRepository.Shop.Items.Count;
        gridObject = new List<GameObject>(ToTalItems);
        shopGrid = new List<ShopGrid>(ToTalItems);
        shopPanel = GameObject.Find("ShopPanel");
        for (int i = 0; i < ToTalItems; i++)
        {
            InstantiateIn(ref gridObject, i, shopPanel);
            shopGrid.Add(gridObject[i].GetComponent<ShopGrid>());
            SetGridInfo(i);
        }
    }


    void OnEnable()
    {
        GridsInstantiate();
    }
    
 
   
    void GridsInstantiate()
    {
        List<Item> items;
        items = DataRepository.Shop.Items;
        for (int i = 0; i < ToTalItems; i++)
            shopGrid[i].Instance(items[i]);
        
        for (int i = 0;i < ToTalItems;i++)
            for(int j = 0;j < DataRepository.User.Purchased.Count;j++)
            {
                if (items[i].Id == DataRepository.User.Purchased[j].Id)
                    shopGrid[i].UnlockItem();
            }
            
            
    }

    void SetGridInfo(int id)
    {

        shopGrid[id].gridID = id;
    }

    void InstantiateIn(ref List<GameObject> listGameobject,int id, GameObject fatherGameobject)
    {
        GameObject newGameobject = Instantiate(gridPrefab);
        newGameobject.name = "Grid" + id.ToString();
        newGameobject.transform.parent = fatherGameobject.transform;
        listGameobject.Add(newGameobject);
    }
    

}
