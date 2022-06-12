using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // points at the Animator of the Character
    public Animator myAnimator;

    // each character has a these values
    public int SpecialDamage;
    public int MaxHealth;
    public int Leben;
    public int Schaden;
    public int Dodge;
    public int Cost;
    public HPBarScript healthbar;

    // Start is called when a the Game Starts, if you want the Stats to be different per Character you can make an onverride function in each child and change the stats
    public virtual void Awake()
    {
        SpecialDamage = 0;
        Leben = 100;
        MaxHealth = Leben;
        Schaden = 25;
        Cost = 3;
        Dodge = 0;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    // take damage
   public virtual void ReduceHealth(int damage)
    {
        Leben -= damage;
        // Debug.Log(Leben);
        healthbar.SetHealth(Leben, MaxHealth);
    }

    // attack an enemy
    public virtual bool Attack(Character Gegner)
    {
        Gegner.ReduceHealth(Schaden);
        if (Gegner.Leben <= 0) return true;
        return false;
    }

    //special attack
    public virtual bool Attack2(Character Gegner)
    {
        Debug.Log("Using Special Attack");
        Gegner.ReduceHealth(SpecialDamage);
        if (Gegner.Leben <= 0) return true;
        return false;
    }


    // die (every child inserts its die animation here)
    public virtual void Die()
    {

    }

    // destroy this gameObject
    public virtual void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    // go into idle state (every child inserts its idle animation here)
    public virtual void Finished()
    {

    }
}
