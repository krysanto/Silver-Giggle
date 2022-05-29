using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public CardScript button1;
    public CardScript button2;
    public CardScript button3;

    // opens the generate Function on every card that can be bought in the shop
    public void OpenShop()
    {
        button1.GenerateShop();
        button2.GenerateShop();
        button3.GenerateShop();
    }

    // deletes all characters still left in the shop after leaving to not have the characters from the last shop in the next shop
    public void CloseShop()
    {
        button1.CloseShop();
        button2.CloseShop();
        button3.CloseShop();
    }
}
