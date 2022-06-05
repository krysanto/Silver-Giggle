using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDragon : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("BabyDragon_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("BabyDragon_Attack");
        return base.Attack(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("BabyDragon_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("BabyDragon_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
