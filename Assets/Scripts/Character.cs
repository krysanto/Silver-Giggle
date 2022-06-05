using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // points at the Animator of the Character
    public Animator myAnimator;

    // each character has a these values
    public int MaxHealth;
    public int Leben;
    public int Schaden;
    public int Cost = 3;
    public HPBarScript healthbar;

    // Start is called when a the Game Starts, if you want the Stats to be different per Character you can make an onverride function in each child and change the stats
    public virtual void Awake()
    {
        Leben = 100;
        MaxHealth = Leben;
        Schaden = 25;
        Cost = 3;
        Debug.Log("Test");
        healthbar.SetHealth(Leben, MaxHealth);
        Debug.Log("Test1");
    }

    // take damage
   public virtual void ReduceHealth(int damage)
    {
        Debug.Log("Schaden -" + Leben);
        Leben -= damage;
        Debug.Log(Leben);
        healthbar.SetHealth(Leben, MaxHealth);
    }

    // attack an enemy
    public virtual bool Attack(Character Gegner)
    {
        Gegner.ReduceHealth(Schaden);
        if (Gegner.Leben <= 0) return true;
        return false;
    }

    public virtual bool Attack2(Character Gegner)
    {
        Gegner.ReduceHealth(Schaden);
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
