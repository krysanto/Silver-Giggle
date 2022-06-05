using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemGreen: Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("GolemGreen_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("GolemGreen_Attack");
        return base.Attack(Gegner);
    }

    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("GolemGreen_Attack2");
        return base.Attack2(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("GolemGreen_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("GolemGreen_Idle");
        base.Finished();
    }
}
