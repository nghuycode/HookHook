using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PUser;
using PModels;

public class ShopGrid : MonoBehaviour
{
    public int gridID;
    public enum state { isLocked,isSelect,isUnselect};
    state curState;
    public Item item;
    public Image shopImg;
    public Text priceText;
    public ShopManager shopManager;
    public void Instance(Item _item)
    {
        item = _item;
        curState = state.isLocked;
        //attach Img
        priceText.text = item.Price.ToString();    
    }
    public void OnClick()
    {
        if(curState == state.isLocked)
        {
            BuyItem();
        }
        else if(curState == state.isUnselect)
        {
            shopManager.shopGrid[shopManager.currentItem].DeSelectItem(); //Get
            SelectItem();
        }
    }

    void BuyItem()
    {
        
        if(DataRepository.User.Money >= item.Price)
        {
            Debug.Log("mua dc");
            //Add item
            UnlockItem();
            DataRepository.User.Money -= item.Price;
        }
    }


    public void UnlockItem()
    {
        curState = state.isUnselect;
        priceText.text = "Choose".ToString();
        //Change Img
    }

    public void SelectItem()
    {
        shopManager.currentItem = gridID;
        curState = state.isSelect;
        priceText.text = "IsSelect".ToString();
        this.gameObject.GetComponent<Button>().enabled = false;
    }

    public void DeSelectItem()
    {
        curState = state.isUnselect; //Get
        priceText.text = "Choose".ToString();
        this.gameObject.GetComponent<Button>().enabled = true;
    }
}
