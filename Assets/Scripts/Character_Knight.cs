using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Knight : Character
{
    public override void reduceHealth(int damage)
    {
        
        base.reduceHealth(damage);
    }
    // Start is called before the first frame update

    public override bool attack(Character Gegner)
    {
        Debug.Log("Playing Animation Knight_Attack");
        myAnimator.Play("Knight_Attack");
        return base.attack(Gegner);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
