using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    enum States
    {
        Idle,
        Attack,
        SpecialAttack,
        Hurt,
        Death
    }
    States Status;
    public Animator myAnimator;
    public int Leben;
    public int Position;
    public int Schaden;

    // Start is called before the first frame update
    void Awake()
    {
        Status = States.Idle;
        Leben = 100;
        Schaden = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public virtual void ReduceHealth(int damage)
    {
        Status = States.Hurt;
        Debug.Log("Schaden -" + Leben);
        Leben -= damage;
        Debug.Log(Leben);
    }

    public virtual bool Attack(Character Gegner)
    {
        Status = States.Attack;
        Gegner.ReduceHealth(Schaden);
        if (Gegner.Leben <= 0) return true;
        return false;
    }

    public virtual void PrintName()
    {
        Debug.Log("No Name");
    }

    public virtual void Die()
    {

    }

    public virtual void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    public virtual void Finished()
    {
        Status = States.Idle;
    }

    private void FixedUpdate()
    {
    }
}
