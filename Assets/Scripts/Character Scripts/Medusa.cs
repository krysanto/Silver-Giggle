using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : Character
{
    public int Armor = 0;

    public override void Awake()
    {
        Leben = 125;
        MaxHealth = Leben;
        Schaden = 40;
        Dodge = 30;
        Cost = 4;
        SpecialDamage = Schaden;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            damage -= Armor;
            if (damage < 0) damage = 0;
            myAnimator.Play("Medusa_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            Armor += 5;
            myAnimator.Play("Medusa_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Medusa_Attack");
            return base.Attack(Gegner);
        }
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
