using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Folder where all characters should be created
    public Transform CharacterFolder;

    // number of Characters you have, can be max 7
    public int CharactersOwned = 0;
    // list of allies and allies that should currently be displayed
    //if a character dies in a round it should not be removed from the team, but only from the combat
    public List<Character> CharacterList = new List<Character>();
    public List<Character> CharactersDisplayed = new List<Character>();

    // list of enemies and enemies that should currently be displayed
    public List<Character> EnemyList = new List<Character>();
    public List<Character> EnemiesDisplayed = new List<Character>();

    // list of all enemies, if there is time link this to List of enemies and get the characters from there
    // that way if you create a new character they only have to be added there and not also here

    public Enemies EnemyController;

    // shows the current Stats of the player
    public int Round = 1;
    public int Gold = 0;
    public int Health = 20;

    // get text to change HP and Gold
    public Text Healthshop;
    public Text Healthfight;

    public Text Goldshop;
    public Text Goldfight;

    public Text Roundshop;
    public Text Roundfight;

    // adds a character to the CharacterList as long as your team isnt full
    public void AddCharacterToList(Character CharacterToAdd)
    {
        Debug.Log("Adding Character");
        if(CharactersOwned+1 > 7) return;
        CharacterList.Add(CharacterToAdd);
        CharactersOwned++;
        UpdateCharactersDisplayed();
    }

    // instantiates a character at a specific place on the scene 
    public Character PrintCharacter(Character CharacterToPrint, int x)
    {
        if (CharacterToPrint != null)
        {
            return Instantiate(CharacterToPrint, new Vector3(CharacterFolder.position.x + -3 - x, (x % 3) * 3 - 3.5f, CharacterFolder.position.z), Quaternion.identity, CharacterFolder);
        }
        else
        {
            return null;
        }
    }

    public void Start()
    {
        Healthshop.text = Health + " Health";
        Healthfight.text = Health + " Health";
        Goldshop.text = Gold + " Gold";
        Goldfight.text = Gold + " Gold";
    }

    public void UpdateHPandGold()
    {
        Healthshop.text = Health + " Health";
        Healthfight.text = Health + " Health";
        Goldshop.text = Gold + " Gold";
        Goldfight.text = Gold + " Gold";
        Roundfight.text = "Round: " + Round.ToString();
        Roundshop.text = "Round: " + Round.ToString();
    }

    // executes the PrintCharacter function on every character in the List
    private void PrintCharacters()
    {
        if(CharacterList.Count > 0)
        { 
            // counter is used to show at which position the character should be created
            int counter = 0;
            foreach (Character c in CharacterList) {
                CharactersDisplayed.Add( PrintCharacter(c, counter) );
                counter++;
            }
        }
    }

    // instantiates a character at a specific place on the scene (the + and - of the x coordinate is flipped to create them on the other side of the bord)
    public Character PrintEnemy(Character EnemyToPrint, int x)
    {
        if (EnemyToPrint != null)
        {
            return Instantiate(EnemyToPrint, new Vector3(CharacterFolder.position.x + 3 + x, (x % 3) * 3 - 3.5f, CharacterFolder.position.z), Quaternion.Euler(new Vector3(0, 180, 0)), CharacterFolder);
        } else
        {
            return null;
        }
    }

    // executes the PrintEnemies function on every character in the List
    public void PrintEnemies()
    {
        if (EnemyList.Count > 0)
        {
            // counter is used to show at which position the character should be created
            int counter = 0;
            foreach (Character c in EnemyList)
            {
                EnemiesDisplayed.Add(PrintEnemy(c, counter));
                counter++;
            }
        }
    }

    // removes all Characters from the Scene and then reprints them 
    public void UpdateCharactersDisplayed()
    {
        ClearCharacters();
        PrintCharacters();
    }

    // gets a new EnemyList from the EnemyController with the current Round and prints it, if it isnt null
    public void NextRound()
    {
        Debug.Log("Next Round");
        if ((EnemyList = EnemyController.getEnemies(Round)) != null)
        {
            ClearCharacters();
            PrintCharacters();
            PrintEnemies();
        }
    }

    // clears all characters
    public void ClearCharacters()
    {
        foreach (Character i in CharactersDisplayed)
        if(i != null) Destroy(i.gameObject);
        foreach (Character i in EnemiesDisplayed)
        if (i != null) Destroy(i.gameObject);
        CharactersDisplayed.Clear();
        EnemiesDisplayed.Clear();
    }
    
    // clears only enemies
    public void ClearEnemies()
    {
        foreach (Character i in EnemiesDisplayed)
        if(i != null) Destroy(i.gameObject);
        EnemiesDisplayed.Clear();
    }

    // returs a list of all characters displayed
    public List<Character> GetCharacters()
    {
        return CharactersDisplayed;
    }

    // returns a list of all enemies displayed
    public List<Character> GetEnemies()
    {
        return EnemiesDisplayed;
    }
}
