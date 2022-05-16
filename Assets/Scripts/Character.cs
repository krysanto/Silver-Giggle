using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int[] array = { 3, 2, 1 };
    public int Leben;
    public int Position;
    public int Schaden = 50;

    // Start is called before the first frame update
    void Start()
    {
        Leben = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public virtual void reduceHealth(int damage)
    {
        Leben -= damage;
        Debug.Log(Leben);
    }

    public bool attack(Character Gegner)
    {
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
        Destroy(this.gameObject);
    }
}
