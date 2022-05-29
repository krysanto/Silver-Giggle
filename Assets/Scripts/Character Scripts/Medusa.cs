using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Medusa_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Medusa_Attack");
        return base.Attack(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Medusa_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Medusa_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
