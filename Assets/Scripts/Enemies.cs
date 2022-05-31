using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // all characters
    public Character Knight;
    public Character BabyDragon; 
    public Character Dragon;
    public Character Demon;
    public Character Wraith;

    // lists what characters are on the enemy team, always has to be 7, where 0 is nobody
    static public int[,] EnemyGroups = {
        { 2, 2, 2, 2, 0, 0, 0 },
        { 2, 3, 4, 4, 0, 0, 0 }
    };

    // gets a list of characters (enemies) at a given round
    public List<Character> getEnemies(int Round)
    {
        List<Character> EnemyGroup = new List<Character>();
        switch (Round){
            case 0:
                EnemyGroup.Add(BabyDragon);
                break;
            case 1:
                EnemyGroup.Add(BabyDragon);
                EnemyGroup.Add(BabyDragon);
                break;
            case 2:
                EnemyGroup.Add(Dragon);
                break;
            case 3:
                EnemyGroup.Add(Dragon);
                EnemyGroup.Add(Dragon);
                break;
            case 4:
                EnemyGroup.Add(BabyDragon);
                EnemyGroup.Add(Dragon);
                EnemyGroup.Add(Demon);
                break;
            case 5:
                EnemyGroup.Add(Demon);
                EnemyGroup.Add(Demon);
                EnemyGroup.Add(Demon);
                break;
            case 6:
                EnemyGroup.Add(Wraith);
                EnemyGroup.Add(Knight);
                EnemyGroup.Add(Knight);
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case '_':
                break;
        }


        /*We Hardcode stuff now lol 
        // if round is higher than roundscreated just start at 0 again
        Round = Round % RoundsCreated;
        // fills a list with characters based on EnemyGroups and then returns it 
        List<Character> EnemyGroup = new List<Character>();
        int counter = 0;
        for(int iter = 0; iter < 7; ++iter)
        {
            switch (EnemyGroups[Round, iter])
            {
                case 0: EnemyGroup.Add(null); break;
                case 1: EnemyGroup.Add(BabyDragon); break;
                case 2: EnemyGroup.Add(Dragon); break;
                case 3: EnemyGroup.Add(Demon); break;
                case 4: EnemyGroup.Add(Wraith); break;
                case 5: EnemyGroup.Add(Knight); break;
                default: Debug.Log("Error, Object " + Round + "|" + iter + "Cant be generated"); break;
            }
            counter++;
        }
        */
        return EnemyGroup;
    }

    // gets a singular character 
    public Character GetCharacter(int option)
    {
        switch (option)
        {
            case 0: return null;
            case 1: return BabyDragon;
            case 2: return Dragon;
            case 3: return Demon;
            case 4: return Wraith;
            case 5: return Knight;
            default: return null;
        }
    }
}
