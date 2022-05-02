using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform CharacterFolder;
    public List<Character> CharacterList = new List<Character>();
    public int CharactersOwned = 0;
    public List<Character> CharactersDisplayed = new List<Character>();

    public GameObject BabyDragon;
    public GameObject Dragon;
    public GameObject Demon;
    public GameObject Wraith;

    // Start is called before the first frame update
    void Start()
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

    public void PrintCharacter(Character CharacterToPrint, int x)
    {
        Instantiate(CharacterToPrint, new Vector3(x*2, 0, 0), Quaternion.identity, CharacterFolder); 
    }

    private void PrintCharacters()
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject i in toDestroy) Destroy(i.gameObject);
        int counter = 0;
        foreach (Character c in CharactersDisplayed) {
            PrintCharacter(c, counter);
            counter++;
        }
    }

    private void UpdateCharactersDisplayed()
    {
        CharactersDisplayed = CharacterList;
        PrintCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
