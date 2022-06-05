using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Rogue_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Rogue_Attack");
        return base.Attack(Gegner);
    }

    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("Rogue_Attack2");
        return base.Attack2(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Rogue_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Rogue_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
