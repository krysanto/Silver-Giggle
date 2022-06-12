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
    public Character WraithBlue;
    public Character Mage;
    public Character Medusa;
    public Character Jinn;
    public Character Rogue;
    public Character Golem;
    public Character GolemGreen;
    public Character Wraith;

    // gets a list of characters (enemies) at a given round
    public List<Character> getEnemies(int Round)
    {
        List<Character> EnemyGroup = new List<Character>();
        switch (Round){
            case 1: // 2
                EnemyGroup.Add(BabyDragon);
                break;
            case 2: // 4
                EnemyGroup.Add(Wraith);
                EnemyGroup.Add(Wraith);
                break;
            case 3: // 5
                EnemyGroup.Add(Golem);
                EnemyGroup.Add(Golem);
                EnemyGroup.Add(GolemGreen);
                break;
            case 4: // 9
                EnemyGroup.Add(Knight);
                EnemyGroup.Add(Mage);
                EnemyGroup.Add(Rogue);
                break;
            case 5: // 10
                EnemyGroup.Add(Dragon);
                EnemyGroup.Add(BabyDragon);
                EnemyGroup.Add(BabyDragon);
                break;
            case 6: // 12
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

        int AmountOfEnemies = Random.Range(3, 6);
        for (int iter = 0; iter < AmountOfEnemies; ++iter)
        {
            int RandomInt = Random.Range(1, 13);
            switch (RandomInt)
            {
                case 0: EnemyGroup.Add(null); break;
                case 1: EnemyGroup.Add(BabyDragon); break;
                case 2: EnemyGroup.Add(Dragon); break;
                case 3: EnemyGroup.Add(Demon); break;
                case 4: EnemyGroup.Add(WraithBlue); break;
                case 5: EnemyGroup.Add(Knight); break;
                case 6: EnemyGroup.Add(Mage); break;
                case 7: EnemyGroup.Add(Medusa); break;
                case 8: EnemyGroup.Add(Jinn); break;
                case 9: EnemyGroup.Add(Rogue); break;
                case 10: EnemyGroup.Add(Golem); break;
                case 11: EnemyGroup.Add(GolemGreen); break;
                case 12: EnemyGroup.Add(Wraith); break;
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
            case 4: return WraithBlue;
            case 5: return Knight;
            case 6: return Mage;
            case 7: return Medusa;
            case 8: return Jinn;
            case 9: return Rogue;
            case 10: return Golem;
            case 11: return GolemGreen;
            case 12: return Wraith;
            default: return null;
        }
    }
}
