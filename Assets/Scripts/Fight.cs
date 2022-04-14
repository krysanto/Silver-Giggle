using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public Character Player1;
    public Character Player2;

   public void combat()
    {
        Debug.Log("Hallo!");
        Player1.attack(Player2);
        Player2.attack(Player1);
    }
}
