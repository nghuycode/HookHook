using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PUser;
public class StartMoneyBar : MonoBehaviour
{
    public Text MoneyText;
    int currentMoney;
    void OnEnable()
    {
        currentMoney = GetMoneyFromUser();
    }

    void Update()
    {
        MoneyText.text = currentMoney.ToString();    
    }
    int GetMoneyFromUser()
    {
        int userMoney = 0;
        userMoney = UserRepository.User.Money;
        return userMoney;
    }
}
