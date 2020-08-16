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
    List<GameObject> gridObject;
    public List<ShopGrid> shopGrid;
    Shop shop;
    User user;
    GameObject shopPanel;
    public GameObject gridPrefab;


    
    void Awake()
    {
        gridObject = new List<GameObject>(ToTalItems);
        shopGrid = new List<ShopGrid>(ToTalItems);
        shopPanel = GameObject.Find("ShopPanel");
        for (int i = 0; i < ToTalItems; i++)
        {
            InstantiateIn(gridObject[i], shopPanel);
            shopGrid[i] = gridObject[i].GetComponent<ShopGrid>();
            SetGridInfo(i);
        }
        
    }

    void OnEnable()
    {
        GetDataFromShop();
        GridsInstantiate();
    }
    
    void GetDataFromShop()
    {
        shop = DataRepository.Shop;
        ToTalItems = shop.Items.Count;

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
        gridObject[id].name = "Grid" + id.ToString();
        shopGrid[id].gridID = id;
    }

    void InstantiateIn(GameObject newGameobject, GameObject fatherGameobject)
    {
        newGameobject = Instantiate(gridPrefab);
        newGameobject.transform.parent = fatherGameobject.transform;
    }
    

}
