using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Mage_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Mage_Attack");
        return base.Attack(Gegner);
    }

    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("Mage_Attack2");
        return base.Attack2(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Mage_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Mage_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
