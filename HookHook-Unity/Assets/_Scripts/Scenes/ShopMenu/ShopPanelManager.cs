using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PShop;
using PUser;


public class ShopPanelManager : MonoBehaviour
{
    protected List<Item> shopItems;
    protected User user;
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
        SetButtonOpacity(tabButton, 1f);
        isSelect = true;
        Panel.SetActive(true);
    }

    public void DeActivePanel()
    {
        SetButtonOpacity(tabButton, 0.6f);
        isSelect = false;
        Panel.SetActive(false);
    }

    void SetButtonOpacity(Button button,float opacity)
    {
        Color temp = button.image.color;
        temp.a = opacity;
        button.image.color = temp;
    }
   
    protected void GridsInstantiate()
    {

        for (int i = 0; i < ToTalItems; i++)
            shopGrid[i].Instance(shopItems[i]);
        
        for (int i = 0;i < ToTalItems;i++)
            for(int j = 0;j < user.Purchased.Count;j++)
            {
                if (shopItems[i].Id == user.Purchased[j].Id)
                    shopGrid[i].UnlockItem();
            }
            
            
    }

    protected void SetGridInfo(int id)
    {

        shopGrid[id].gridID = id;
        shopGrid[id].baseManager = this;
    }

    protected void InstantiateIn(ref List<GameObject> listGameobject,int id, GameObject fatherGameobject)
    {
        
        GameObject newGameobject = Instantiate(gridPrefab);
        newGameobject.name = "Grid" + id.ToString();
        newGameobject.transform.SetParent(fatherGameobject.transform);
        listGameobject.Add(newGameobject);
    }
    

}
