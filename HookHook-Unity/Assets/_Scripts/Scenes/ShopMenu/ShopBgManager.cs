using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PShop;
using PUser;
using PHelper;



public class ShopBgManager : ShopPanelManager
{
    void Awake()
    {
        isSelect = false;
        user = UserRepository.User;
        shopItems = ShopRepository.Shop.Items.GetBackgrounds();
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
        Invoke("Initialization", 0.0001f);

    }

    void Initialization()
    {
       // user = UserRepository.User;
        DeActivePanel();
        GridsInstantiate();
        shopGrid[GetGridIndex(user.currentBackground.Id)].SelectItem();
    }

}
