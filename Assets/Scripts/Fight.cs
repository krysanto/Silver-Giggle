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
    
    public bool FightFinished = true;
    public bool CombatFinished = true;

    public void StartCombat()
    {
        Debug.Log("Starting Combat!");

        Characters = GameController.GetCharacters();
        Enemies = GameController.GetEnemies();

        Debug.Log("Fetched Characters and Enemies:");
        Debug.Log(Characters);
        Debug.Log(Enemies);
        
        CombatFinished = false;
        FightFinished = true;

    }

    private void Update()
    {
        if (!CombatFinished)
        {
            if (FightFinished)
            {
                if (Characters.Count > 0 && Enemies.Count > 0)
                {
                    FightFinished = false;
                    Debug.Log("Fighting...");
                    StartCoroutine(BattleEachother(Characters.Find(x => true), Enemies.Find(x => true)));
                } else
                {
                    CombatFinished = true;
                    Debug.Log("Combat Ended");
                }
            }
        }
    }

    public IEnumerator BattleEachother(Character First, Character Second)
    {
        bool turnorder = true;

        bool enemydead = false;
        bool allydead = false;

        while (!allydead && !enemydead)
        {
            if (turnorder) { 
                enemydead = First.Attack(Second);
                turnorder = false;

                if (enemydead)
                {
                    Enemies.Remove(Second);
                    Second.Die();
                }
            } else { 
                allydead = Second.Attack(First);
                turnorder = true;

                if (allydead)
                {
                    Characters.Remove(First);
                    First.Die();
                }
            }
            yield return new WaitForSeconds(1);
            if(enemydead || allydead) FightFinished = true;
        }
    }
}
