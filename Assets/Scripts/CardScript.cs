using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int option;
    public Enemies ListOfCharacters;
    public Character myCharacter;

    public Transform thisCard;
    public Character createdCharacter;
    
    public GameController GameController;

    bool active;

    public void GenerateShop()
    {
        active = true;
        myCharacter = null;
        while (myCharacter == null)
        {
            option = Random.Range(0, 5);
            myCharacter = ListOfCharacters.GetCharacter(option);
        }
        createdCharacter = Instantiate(myCharacter, new Vector3(thisCard.position.x, thisCard.position.y, thisCard.position.z - 1), Quaternion.Euler(new Vector3(0, 180, 0)), thisCard);
        createdCharacter.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }

    public void CloseShop()
    {
        if (createdCharacter != null)
        {
            Destroy(createdCharacter.gameObject);
        }
    }

    public void PurchaseCharacter()
    {
        if (active == true)
        {
            active = false;
            Debug.Log("Purchasing Character");
            GameController.AddCharacterToList(myCharacter);
            Destroy(createdCharacter.gameObject);
        }
    }
}

