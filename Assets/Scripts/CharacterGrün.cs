using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrün : Character
{
    public override void reduceHealth(int damage)
    {
        Leben -= 2;
        Debug.Log(Leben);
    }
}
