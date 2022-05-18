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

   public virtual void reduceHealth(int damage)
    {
        //myAnimator.Play("Dragon_Hurt");
        Status = States.Idle;
        Debug.Log("Schaden -" + Leben);
        Leben -= damage;
        Debug.Log(Leben);
    }

    public virtual bool attack(Character Gegner)
    {
        Debug.Log("Playing Animation Dragon_Attack");
        myAnimator.Play("Dragon_Attack");
        Status = States.Attack;
        Gegner.reduceHealth(Schaden);
        if (Gegner.Leben <= 0) return true;
        return false;
    }

    public virtual void printName()
    {
        Debug.Log("No Name");
    }

    public void DestroyMe()
    {
        myAnimator.Play("Dragon_Death");
        Status = States.Death;
        Destroy(this.gameObject);
    }

    public void Finished()
    {
        Status = States.Idle;
        myAnimator.Play("Dragon_Idle");
    }
}
