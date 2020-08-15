using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMoneyBar : MonoBehaviour
{
    public Text MoneyText;
    int currentMoney;

    void Start()
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
        return userMoney;
    }
}
