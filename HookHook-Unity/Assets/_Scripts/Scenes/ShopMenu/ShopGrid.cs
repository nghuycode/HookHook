using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PUser;


public class ShopGrid : MonoBehaviour
{
    public int gridID;
    public enum state { isLocked,isSelect,isUnselect};
    public state curState;
    public Item item;
    public Image shopImg;
    public Text priceText;
    public ShopPanelManager baseManager;
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
            baseManager.shopGrid[baseManager.currentItem].DeSelectItem(); //Get
            SelectItem();
        }
    }

    void BuyItem()
    {
        if(UserRepository.Buy(item))
        {
            UnlockItem();
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
        baseManager.currentItem = gridID;
        curState = state.isSelect;
        priceText.text = "IsSelect".ToString();
        this.gameObject.GetComponent<Button>().enabled = false;
    }

    public void DeSelectItem()
    {
        curState = state.isUnselect; 
        priceText.text = "Choose".ToString();
        this.gameObject.GetComponent<Button>().enabled = true;
    }
}
