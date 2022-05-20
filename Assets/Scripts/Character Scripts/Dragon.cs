using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Dragon_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Dragon_Attack");
        return base.Attack(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Dragon_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Dragon_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
