using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int[] array = { 3, 2, 1 };
    public int Leben;
    public int Position;


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
        Debug.Log(array[2]);
    }

    public void attack(Character Gegner)
    {
        Gegner.reduceHealth(1);
    }

    public virtual void printName()
    {
        Debug.Log("No Name");
    }
}
