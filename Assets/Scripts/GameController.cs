using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform CharacterFolder;

    public int CharactersOwned = 0;
    public List<Character> CharacterList = new List<Character>();
    public List<Character> CharactersDisplayed = new List<Character>();

    public List<Character> EnemyList = new List<Character>();
    public List<Character> EnemiesDisplayed = new List<Character>();

    public GameObject BabyDragon;
    public GameObject Dragon;
    public GameObject Demon;
    public GameObject Wraith;

    public Enemies EnemyController;

    public int Round = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void GenerateEnemies(List<Character> Enemies)
    {

    }

    public void AddCharacterToList(Character CharacterToAdd)
    {
        Debug.Log("Adding Character");
        if(CharactersOwned+1 > 7) return;
        CharacterList.Add(CharacterToAdd);
        CharactersOwned++;
        UpdateCharactersDisplayed();
    }

    public void MoveCharacter(int pos1, int pos2)
    {
        Character Temp = CharacterList[pos2];
        CharacterList[pos2] = CharacterList[pos1];
        CharacterList[pos1] = Temp;
    }

    public void RemoveCharacterFromList(Character CharacterToRemove)
    {
        if(CharacterList.Remove(CharacterToRemove));
        {
            CharactersOwned--;
        }
    }

    public Character PrintCharacter(Character CharacterToPrint, int x)
    {
        return Instantiate(CharacterToPrint, new Vector3(CharacterFolder.position.x + -3 - x, x%2*2-1, CharacterFolder.position.z), Quaternion.identity, CharacterFolder); 
    }

    private void PrintCharacters()
    {
        if(CharacterList.Count > 0)
        { 
            int counter = 0;
            foreach (Character c in CharacterList) {
                CharactersDisplayed.Add( PrintCharacter(c, counter) );
                counter++;
            }
        }
    }

    public Character PrintEnemy(Character EnemyToPrint, int x)
    {
        return Instantiate(EnemyToPrint, new Vector3(CharacterFolder.position.x + 3 + x, x % 2 * 2 - 1, CharacterFolder.position.z), Quaternion.Euler(new Vector3(0,180,0)), CharacterFolder);
    }

    public void PrintEnemies()
    {
        if (EnemyList.Count > 0)
        {
            int counter = 0;
            foreach (Character c in EnemyList)
            {
                EnemiesDisplayed.Add(PrintEnemy(c, counter));
                counter++;
            }
        }
    }

    private void UpdateCharactersDisplayed()
    {
        ClearCharacters();
        PrintCharacters();
    }

    public void NextRound()
    {
        Debug.Log("Next Round");
        if ((EnemyList = EnemyController.getEnemies(Round)) != null)
        {
            ClearCharacters();
            PrintCharacters();
            PrintEnemies();
        }
        Round++;
    }

    public void ClearCharacters()
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject i in toDestroy) Destroy(i.gameObject);
        CharactersDisplayed.Clear();
        EnemiesDisplayed.Clear();
    }

    public List<Character> GetCharacters()
    {
        return CharactersDisplayed;
    }

    public List<Character> GetEnemies()
    {
        return EnemiesDisplayed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
