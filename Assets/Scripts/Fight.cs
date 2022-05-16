using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public List<Character> Characters;
    public Character Character;
    public List<Character> Enemies;
    public Character Enemy;
    public GameController GameController;

    public void StartCombat()
    {
        Debug.Log("Starting Combat!");

        Characters = GameController.GetCharacters();
        Enemies = GameController.GetEnemies();

        Debug.Log("Fetched Characters and Enemies:");
        Debug.Log(Characters);
        Debug.Log(Enemies);

        CombatCycle();
    }

    public void CombatCycle()
    {
        int I = 10;
        while (Characters.Count > 0 && Enemies.Count > 0 && I > 0)
        {
            Debug.Log("Fighting...");
            BattleEachother(Characters.Find(x => true), Enemies.Find(x => true));
            I--;
        }
        Debug.Log("Combat Ended");
    }

    public void BattleEachother(Character First, Character Second)
    {
        while(First.Leben > 0 && Second.Leben > 0){
            if(First.attack(Second))
            {
                Characters.Remove(First);
                First.DestroyMe();
            }
            if(Second.attack(First))
            {
                Enemies.Remove(Second);
                Second.DestroyMe();
            }
        }
    }
}
