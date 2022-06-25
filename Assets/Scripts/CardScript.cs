using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    // displays which character(number) was picked for this card
    public int option;
    
    // displays which character was picked for this card and points to the clone of the character
    public Character myCharacter;

    // variables used for displaying character stats
    public int HP;
    public int damage;
    public int cost;
    public Character createdCharacter;

    // place where the character is supposed to be created
    public Transform thisCard;

    // other scripts used in this one, GameController to subtract money when a card is bought and ListofCharacters to see what Characters exist
    public Enemies ListOfCharacters;
    public GameController GameController;

    // shows whether or not a card can be bought or was already bought
    bool active = true;

    // all textboxes where the text will be changed
    public Text Textbox;
    public Text Statsbox;

    // at the start of the program generates the first shop
    private void Start()
    {
        GenerateShop();    
    }

    public void GenerateShop()
    {
        active = true;
        // tries to pick a random character until a character could be assigned
        myCharacter = null;
        while (myCharacter == null)
        {
            option = Random.Range(1, 14);
            myCharacter = ListOfCharacters.GetCharacter(option);
            if(myCharacter != null && myCharacter.Cost > GameController.Gold)
            {
                myCharacter = null;
            }
        }
        Vector3 myVector;
        // changed the position of the character to fit the card (not completel due to lack of time)
        switch (option)
        {
            case 1: myVector = new Vector3(thisCard.position.x - 0.24f, -0.75f, thisCard.position.z - 1); break;
            default: myVector = new Vector3(thisCard.position.x, thisCard.position.y, thisCard.position.z - 1); break;
        }
        // instantiate creates a copy of Character, - Instantiate(Object to Instantiate, Coordinates, Rotation, ordner where it should be moved) 
        createdCharacter = Instantiate(myCharacter, myVector, Quaternion.Euler(new Vector3(0, 180, 0)), thisCard);
       
        //createdCharacter.transform.localScale += new Vector3(1f, 1f, 1);
        // create statstextbox
        HP = createdCharacter.Leben;
        damage = createdCharacter.Schaden;
        cost = createdCharacter.Cost;
        Statsbox.text = "";
        Statsbox.text += "HP: ";
        Statsbox.text += HP.ToString();
        Statsbox.text += "\nDamage: ";
        Statsbox.text += damage.ToString();
        Textbox.text = cost.ToString();
    }

    public void CloseShop()
    {
        // when the shop gets closed and there is still a character in the card, remove the character from the scene
        if (createdCharacter != null)
        {
            Destroy(createdCharacter.gameObject);
        }
        myCharacter = null;
    }

    public void PurchaseCharacter()
    {
        // if the card is still active and i have enough Gold to purchase the character
        if (active == true && GameController.Gold - cost >= 0 && GameController.CharactersOwned < 7)
        {
            active = false;
            Debug.Log("Purchasing Character");
            GameController.Gold -= cost;
            Textbox.text = "0";
            // adds the character to list of allies
            GameController.AddCharacterToList(myCharacter);
            myCharacter = null;
            // destroys the clone that is still inside the card
            Destroy(createdCharacter.gameObject);
            GameController.UpdateHPandGold();
        }
    }
}

