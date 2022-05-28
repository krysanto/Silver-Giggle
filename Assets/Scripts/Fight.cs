using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Fight : MonoBehaviour
{
    public List<Character> Characters;
    public Character Character;
    public List<Character> Enemies;
    public Character Enemy;
    public GameController GameController;

    public Shop Shop;

    //Camerachange script object
    public GameObject changeCamera;
    
    public bool FightFinished = true;
    public bool CombatFinished = true;

    public void StartCombat()
    {
        Shop.CloseShop();
        Debug.Log("Starting Combat!");

        Characters = GameController.GetCharacters();
        Enemies = GameController.GetEnemies();

        Debug.Log("Fetched Characters and Enemies:");
        Debug.Log(Characters);
        Debug.Log(Enemies);
        
        CombatFinished = false;
        FightFinished = true;

    }

    private IEnumerator Waiter()
    {
        Debug.Log("Waiting for 7 seconds");
        yield return new WaitForSeconds (7);
        Debug.Log("Finished Waiting");
        Debug.Log("Before scenechange");
        
        Debug.Log("AFter scenechange");
        
    }

    private  void FinishFight()
    {
        Debug.Log("Fight is finished, changeing scene");
        //StartCoroutine(Waiter());
        ToggleCamera cameraScript = changeCamera.GetComponent<ToggleCamera>();
        cameraScript.ChangeCamera();
        Shop.OpenShop();
        this.enabled = false;
        //changeCamera.GetComponent<ToggleCamera>().ChangeCamera();


    }

    private void Update()
    {
        if (CombatFinished && FightFinished)
        {
            FinishFight();
        }


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
                    GameController.ClearEnemies();
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
