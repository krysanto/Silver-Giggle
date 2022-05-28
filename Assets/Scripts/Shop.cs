using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public CardScript button1;
    public CardScript button2;
    public CardScript button3;

    public void OpenShop()
    {
        button1.GenerateShop();
        button2.GenerateShop();
        button3.GenerateShop();
    }

    public void CloseShop()
    {
        button1.CloseShop();
        button2.CloseShop();
        button3.CloseShop();
    }
}
