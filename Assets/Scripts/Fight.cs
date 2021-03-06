using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

// this Code handels how Fights should take place and what events should be called after and before a fight
public class Fight : MonoBehaviour
{
    // list of allies and enemies in a fight
    public List<Character> Allies;
    public List<Character> Enemies;

    public GameController GameController;

    // used to open the Shop after the fight
    public Shop Shop;

    // camerachange script object
    public GameObject changeCamera;
    
    // indicates whether or not a fight has finished
    public bool FightFinished = true;
    public bool CombatFinished = true;
    // additional bool to not execute FinishFight() twice.
    public bool jumpedToFinish = true;

    public TMP_Text victoryText;
    public TMP_Text defeatText;
    public TMP_Text loseText;
    public TMP_Text goldText;
    public TMP_Text healthText;

    //ChangeScene
    public SceneChanger changeScene;

    //Add Shop Buttons to disable/enable them.
    public GameObject ToggleShopButton;
    public GameObject FirstCardButton;
    public GameObject SecondCardButton;
    public GameObject ThirdCardButton;


    // called at the Start of Combat, Closes the shop and gets the Characters and Enemies from the GameController 
    public void StartCombat()
    {
        Shop.CloseShop();
        Debug.Log("Starting Combat!");

        Allies = GameController.GetCharacters();
        Enemies = GameController.GetEnemies();

        Debug.Log("Locking Shop, Player cant buy!");
        ToggleShopButton.SetActive(false);
        FirstCardButton.SetActive(false);
        SecondCardButton.SetActive(false);
        ThirdCardButton.SetActive(false);

        Debug.Log("Fetched Characters and Enemies:");
        Debug.Log(Allies);
        Debug.Log(Enemies);
        
        CombatFinished = false;
        FightFinished = true;

    }

    // used to wait 7 Seconds before after every fight, then Stats of the Character (in GameController) get changed 
    private IEnumerator Waiter()
    {
        Debug.Log("Waiting for 5 seconds");
        
        Debug.Log("Finished Waiting");
        if (Allies.Count.Equals(0))
        {
            //Get Remaining number of Enemies and lose HP based on that number
            int aliveEnemies = Enemies.Count;
            GameController.Health -= aliveEnemies;
            defeatText.gameObject.SetActive(true);
            if (GameController.Health <= 0)
            {
                loseText.gameObject.SetActive(true);
            }
            else
            {
                healthText.text = "";
                healthText.text += "You have Lost ";
                healthText.text += aliveEnemies;
                if(aliveEnemies > 1)
                {
                    healthText.text += " Healthpoints !";
                } else
                {
                    healthText.text += " Healthpoint !";
                }
                
                healthText.gameObject.SetActive(true);
            }
        }
        else
        {
            victoryText.gameObject.SetActive(true);
            goldText.gameObject.SetActive(true);
        }


        yield return new WaitForSeconds(5);
        victoryText.gameObject.SetActive(false);
        defeatText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        goldText.gameObject.SetActive(false);


        if (GameController.Health <= 0)
        {
            changeScene.ChangeScene("MainMenuScene");
        }

        //Reenable Buttons
        Debug.Log("Player can buy again!");
        ToggleShopButton.SetActive(true);
        FirstCardButton.SetActive(true);
        SecondCardButton.SetActive(true);
        ThirdCardButton.SetActive(true);

        // changes Cameraview
        ToggleCamera cameraScript = changeCamera.GetComponent<ToggleCamera>();
        
        // adds stats and opens the shop again
        GameController.ClearEnemies();
        GameController.Gold += 2;
        GameController.UpdateCharactersDisplayed();
        GameController.UpdateHPandGold();
        
        Shop.OpenShop();
        cameraScript.ChangeCamera();
        this.enabled = false;
    }

    // starts the Waiter 
    private void FinishFight()
    {
        jumpedToFinish = true;
        Debug.Log("Fight is finished");
        GameController.Round++;
        //Enemies.Clear();
        StartCoroutine(Waiter());
    }

    // checks every frame whether or not the current fight is finished or the combat is finished
    // if the fight is finished but not the combat, start the next fight
    // if there are no enemies or allies left to fight, finish the fight and finish the combat
    private void Update()
    {
        if (!CombatFinished)
        {
            if (FightFinished)
            {
                if (Allies.Count > 0 && Enemies.Count > 0)
                {
                    FightFinished = false;
                    Debug.Log("Fighting...");
                    // find(parameter) finds the first Entry in Character for that [parameter] is true 
                    // so if parameter is already true it returns the very first one
                    StartCoroutine(BattleEachother(Allies.Find(x => true), Enemies.Find(x => true)));
                } else
                {
                    jumpedToFinish = false;
                    CombatFinished = true;
                    Debug.Log("Combat Ended");
                }
            }
        }
        else
        {
            if (!jumpedToFinish)
            {
                FinishFight();
            }
        }
    }

    // lets two character (one ally, one enemy) fight eachother
    public IEnumerator BattleEachother(Character Ally, Character Enemy)
    {
        // turnorder = true -> ally's turn to attack | turnorder = false -> enemy's turn to attack
        bool turnorder = true;

        bool enemydead = false;
        bool allydead = false;

        // while none of them are dead
        while (!allydead && !enemydead)
        {
            if (turnorder) { 
                // our ally attacks the enemy and change turn
                enemydead = Ally.Attack(Enemy);
                turnorder = false;

                // if this kills the enemy remove it from the list of enemies and let it Die (this also removes the character from the scene)
                if (enemydead)
                {
                    GameController.Gold += 1;
                    Enemies.Remove(Enemy);
                    Enemy.Die();
                }
            } else { 
                // the enemy attacks our ally and change turn
                allydead = Enemy.Attack(Ally);
                turnorder = true;

                // if this kills the ally remove it from the list of characters and let it Die (this also removes the character from the scene)
                if (allydead)
                {
                    GameController.RemoveFirst();
                    Allies.Remove(Ally);
                    Ally.Die();
                }
            }
            // wait 1 second and check if either are dead
            yield return new WaitForSeconds(1);
            if(enemydead || allydead) FightFinished = true;
        }
    }
}
