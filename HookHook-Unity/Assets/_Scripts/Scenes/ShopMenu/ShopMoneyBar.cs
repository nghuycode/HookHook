using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PModels;
using UnityEngine.UI;

public class ShopMoneyBar : MonoBehaviour
{
    public Text MoneyText;
    int currentMoney;

    void Update()
    {
        currentMoney = GetMoneyFromUser();
        MoneyText.text = currentMoney.ToString();    
    }
    int GetMoneyFromUser()
    {
        int userMoney = 0;
        userMoney = DataRepository.User.Money;
        return userMoney;
    }
}
