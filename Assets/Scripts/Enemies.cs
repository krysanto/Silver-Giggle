using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Character BabyDragon; 
    public Character Dragon;
    public Character Demon;
    public Character Wraith;

    static int RoundsCreated = 2;

    static public int[,] EnemyGroups = {
        { 2, 2, 2, 2, 0, 0, 0 },
        { 2, 3, 4, 4, 0, 0, 0 }
    };

    public List<Character> getEnemies(int Round)
    {
        Round = Round % RoundsCreated;
        List<Character> EnemyGroup = new List<Character>();
        int counter = 0;
        for(int iter = 0; iter < 7; ++iter)
        {
            switch (EnemyGroups[Round, iter])
            {
                case 0: break;
                case 1: EnemyGroup.Add(BabyDragon); break;
                case 2: EnemyGroup.Add(Dragon); break;
                case 3: EnemyGroup.Add(Demon); break;
                case 4: EnemyGroup.Add(Wraith); break;
                default: Debug.Log("Error, Object " + Round + "|" + iter + "Cant be generated"); break;
            }
            counter++;
        }
        return EnemyGroup;
    }
}
