using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PShop;
using PUser;
using PHelper;



public class ShopRopeManager : ShopPanelManager
{
    void Awake()
    {
        isSelect = false;
        user = UserRepository.User;
        shopItems = ShopRepository.Shop.Items.GetRopes();
        ToTalItems = shopItems.Count;
        gridObject = new List<GameObject>(ToTalItems);
        shopGrid = new List<ShopGrid>(ToTalItems);
        for (int i = 0; i < ToTalItems; i++)
        {
            InstantiateIn(ref gridObject, i, Panel);
            shopGrid.Add(gridObject[i].GetComponent<ShopGrid>());
            SetGridInfo(i);
        }
    }

    void OnEnable()
    {
        Invoke("DeActivePanel", 0.0001f);
        GridsInstantiate(); 
        shopGrid[GetGridIndex(user.currentRope.Id)].SelectItem();
    }
    

}
