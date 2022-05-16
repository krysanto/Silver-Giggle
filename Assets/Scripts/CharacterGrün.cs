using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrün : Character
{
    public override void reduceHealth(int damage)
    {
        Leben -= damage;
        if (Leben <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Died");
        }
        Debug.Log(Leben);
    }

    public override void printName()
    {
        Debug.Log("Grün");
    }
}
