using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PUser;

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
        userMoney = UserRepository.User.Money;
        return userMoney;
    }
}
