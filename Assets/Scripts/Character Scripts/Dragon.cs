using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is how a normal Character-Child Code should look like
public class Dragon : Character
{
    public override void ReduceHealth(int damage)
    {
        // if you for example were working on a Knight, replace "Dragon_Hurt" with "Knight_Hurt" 
        // and add a "Finished()" Event at the end of every animation (besides Die())
        myAnimator.Play("Dragon_Hurt");
        base.ReduceHealth(damage);
    }

    // Plays its own attack and makes the enemy play the Hurt animation
    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Dragon_Attack");
        return base.Attack(Gegner);
    }

    //SpecialAttack
    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("Dragon_Attack2");
        return base.Attack2(Gegner);
    }

    // add a "DestroyMe()" Event at the end of this animation so the character gets removed from the scene 
    public override void Die()
    {
        myAnimator.Play("Dragon_Death");
        base.Die();
    }

    // goes into idle mode
    public override void Finished()
    {
        myAnimator.Play("Dragon_Idle");
        base.Finished();
    }

    // just opens the base DestroyMe animation, if you want the character to give a specific amount of Gold, the card can be inserted in here
    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
