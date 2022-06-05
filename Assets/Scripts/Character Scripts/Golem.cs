using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem: Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Golem_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Golem_Attack");
        return base.Attack(Gegner);
    }

    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("Golem_Attack2");
        return base.Attack2(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Golem_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Golem_Idle");
        base.Finished();
    }
}
