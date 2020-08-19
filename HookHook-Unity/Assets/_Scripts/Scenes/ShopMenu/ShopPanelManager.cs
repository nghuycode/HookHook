using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PShop;
using PUser;
using PModels;


public class ShopPanelManager : MonoBehaviour
{
    protected int ToTalItems; //Total number of items in shop
    public int currentItem;
    public List<GameObject> gridObject;
    public List<ShopGrid> shopGrid;
    public GameObject Panel;
    public GameObject gridPrefab;
    public Button tabButton;
    protected bool isSelect;

    public void ActivePanel()
    {

        isSelect = true;
        Panel.SetActive(true);
    }

    public void DeActivePanel()
    {
        isSelect = false;
        Panel.SetActive(false);
    }

   
    protected void GridsInstantiate()
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

    protected void SetGridInfo(int id)
    {

        shopGrid[id].gridID = id;
    }

    protected void InstantiateIn(ref List<GameObject> listGameobject,int id, GameObject fatherGameobject)
    {
        GameObject newGameobject = Instantiate(gridPrefab);
        newGameobject.name = "Grid" + id.ToString();
        newGameobject.transform.parent = fatherGameobject.transform;
        listGameobject.Add(newGameobject);
    }
    

}
