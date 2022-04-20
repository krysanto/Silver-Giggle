using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Character[] Characters;

    // Start is called before the first frame update
    void Start()
    {
        Characters = FindObjectsOfType<Character>();
        foreach(Character c in Characters)
        {
            c.printName();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
