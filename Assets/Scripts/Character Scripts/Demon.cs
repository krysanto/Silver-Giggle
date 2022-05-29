using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Demon_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Demon_Attack");
        return base.Attack(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Demon_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Demon_Idle");
        base.Finished();
    }
}
