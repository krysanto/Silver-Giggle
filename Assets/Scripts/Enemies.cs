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
    public Character Mage;

    // gets a list of characters (enemies) at a given round
    public List<Character> getEnemies(int Round)
    {
        List<Character> EnemyGroup = new List<Character>();
        switch (Round){
            case 1:
                EnemyGroup.Add(BabyDragon);
                break;
            case 2:
                EnemyGroup.Add(BabyDragon);
                EnemyGroup.Add(BabyDragon);
                break;
            case 3:
                EnemyGroup.Add(Dragon);
                break;
            case 4:
                EnemyGroup.Add(Dragon);
                EnemyGroup.Add(Dragon);
                break;
            case 5:
                EnemyGroup.Add(BabyDragon);
                EnemyGroup.Add(Dragon);
                EnemyGroup.Add(Demon);
                break;
            case 6:
                EnemyGroup.Add(Demon);
                EnemyGroup.Add(Demon);
                EnemyGroup.Add(Demon);
                break;
            default: EnemyGroup = GenerateRandomRound(); break;
        }

        return EnemyGroup;
    }

    // generates a random array of up to 7 characters
    private List<Character> GenerateRandomRound()
    {
        List<Character> EnemyGroup = new List<Character>();
        int counter = 0;

        int AmountOfEnemies = Random.Range(3, 7);
        for (int iter = 0; iter < AmountOfEnemies; ++iter)
        {
            int RandomInt = Random.Range(1, 5);
            switch (RandomInt)
            {
                case 0: EnemyGroup.Add(null); break;
                case 1: EnemyGroup.Add(BabyDragon); break;
                case 2: EnemyGroup.Add(Dragon); break;
                case 3: EnemyGroup.Add(Demon); break;
                case 4: EnemyGroup.Add(Wraith); break;
                case 5: EnemyGroup.Add(Knight); break;
                case 6: EnemyGroup.Add(Mage); break;
                default: Debug.Log("Error, Enemy in Enemy Round cant be generated"); break;
            }
            counter++;
        }
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
            case 6: return Mage;
            default: return null;
        }
    }
}
