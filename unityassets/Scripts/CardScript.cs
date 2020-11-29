using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{

    //any particular reason these vars are public? This can be expoilted by hackers - endercat
    public Rarity rarity;
    public CardType type;
    public Sprite cardArt;
    public int health;
    public int attack;
    public string cardName;
    public string[] abilityText;
    public string[] flavorText;

    //is card stunned? use getIsStun() to check and updateIsStun(bool value) to update.
    private bool isStun;
    //turns remaining of stun, if stunned.
    private int stunTurns;
    //is card bleeding? use getIsStun() to check and updateIsStun(bool value) to update.
    private bool isBleed;
    //turns remaining of stun, if stunned.
    private int bleedTurns;
    public Image cardBorder;
    public Image cardBackground;

    private string abilityTextFinal;
    private string flavorTextFinal;

    Image rarityColor;
    Image typeImage;

    public enum Rarity {Common, Bronze, Silver, Gold, Mythological}
    public enum CardType {Air, Light, Normal, Fire, Nature, Water, Death}

    public void Start ()
    {
        //This creates the card that the user sees 
        UpdateValues();
    }

    //gets value of isStun -- use to check if card is stunned
    public bool getIsStun()
    {
        return isStun;
    }

    //updates value of isStun, securely
    public void updateIsStun(bool isStun)
    {
        this.isStun = isStun;
    }
    //get val of stun turns, securely
    public int getstunTurns()
    {
        return stunTurns;
    }
    //add x to stun turns, to reduce value, use negative x.
    public void updateStunTurns(int stunTurns)
    {
        this.stunTurns += stunTurns;
    }

    //gets value of isBleed -- use to check if card is bleeding
    public bool getIsBleed()
    {
        return isBleed;
    }

    //updates value of isBleed, securely
    public void updateIsBleed(bool isBleed)
    {
        this.isBleed = isBleed;
    }
    //get val of bleed turns, securely
    public int getbleedTurns()
    {
        return bleedTurns;
    }
    //add x to bleed turns, to reduce value, use negative x.
    public void updateBleedTurns(int bleedTurns)
    {
        this.bleedTurns += bleedTurns;
    }
    //This function changes the color of the RarityPanel depending on the rarity of the card
    public void DefineRarity()
    {
        switch (rarity.ToString())
        {
            case ("Common"):
                rarityColor.color = cardBackground.color;
                return;
            case ("Bronze"):
                rarityColor.color = new Color32(205, 127, 50, 255);
                return;
            case ("Silver"):
                rarityColor.color = new Color32(192, 192, 192, 255);
                return;
            case ("Gold"):
                rarityColor.color = new Color32(255, 215, 0, 255);
                return;
            case ("Mythological"):
                rarityColor.color = new Color32(199, 21, 103, 255);
                return;
        }
    }

    //This function changes the card border and color depending on the type
    public void DefineColors()
    {
        switch (type.ToString())
        {
            case ("Air"):
                cardBorder.color = new Color32(195, 195, 195, 255);
                cardBackground.color = new Color32(255, 255, 255, 255);
                return;
            case ("Light"):
                cardBorder.color = new Color32(200, 190, 0, 255);
                cardBackground.color = new Color32(255, 249, 136, 255);
                return;
            case ("Normal"):
                cardBorder.color = new Color32(88, 88, 88, 88);
                cardBackground.color = new Color32(195, 195, 195, 195);
                return;
            case ("Fire"):
                cardBorder.color = new Color32(176, 35, 0, 255);
                cardBackground.color = new Color32(251, 204, 177, 255);
                return;
            case ("Nature"):
                cardBorder.color = new Color32(4, 134, 26, 255);
                cardBackground.color = new Color32(154, 255, 170, 255);
                return;
            case ("Water"):
                cardBorder.color = new Color32(0, 63, 188, 255);
                cardBackground.color = new Color32(171, 255, 254, 255);
                return;
            case ("Death"):
                cardBorder.color = new Color32(0, 0, 0, 255);
                cardBackground.color = new Color32(139, 136, 134, 255);
                return;
        }
    }

    //This function formats the flavor and ability text arrays into rich text readable by the UI Text properly
    public void TextBreak ()
    {
        foreach (string line in abilityText) {
            if (line == "")
            {
                abilityTextFinal +=  "\n\n";
            } else
            {
                abilityTextFinal += line + "\n";
            }
        }
        foreach (string line in flavorText)
            if (line == "")
            {
                flavorTextFinal += "\n\n";
            }
            else
            {
                string flavorTextTemp = "<i>" + line + "</i>";
                flavorTextFinal += flavorTextTemp + "\n";
            }
    }

    /*Parameters - 
    diceSides - number of sides on dice, for a d6, it would be 6
    */
    public int DiceRoll(int diceSides)
    {
        
        //returns random int between 1 & diceSides
        return (int) (Random.Range(1, (diceSides-1)*1f));
    }

    //When health changes, call this function. This means that we don't have to check it in Update.
    //Note, could also be used to check for death contextual skills, place before Destroy(gameObject) to use in this way - endercat
    public void CheckForDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Updates card based on value variables
    public void UpdateValues()
    {
        //This makes the name appear in bold on the card
        string cardNameFinal = "<b>" + cardName + "</b>";

        //This readies the ability + flavor text to be used on the card
        TextBreak();

        RectTransform[] children = GetComponentsInChildren<RectTransform>();
        //This assigns the graphic of the card the data it needs from the variables
        foreach (RectTransform child in children)
        {
            switch (child.gameObject.tag)
            {
                case "Art":
                    child.GetComponent<Image>().sprite = cardArt;
                    break;
                case "Health":
                    child.GetComponent<Text>().text = health.ToString();
                    break;
                case "Attack":
                    child.GetComponent<Text>().text = attack.ToString();
                    break;
                case "Type":
                    child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Types/" + type.ToString());
                    break;
                case "RarityPanel":
                    rarityColor = child.GetComponent<Image>();
                    break;
                case "Border":
                    cardBorder = child.GetComponent<Image>();
                    break;
                case "Background":
                    cardBackground = child.GetComponent<Image>();
                    break;
                case "Name":
                    child.GetComponent<Text>().text = cardNameFinal;
                    break;
                case "Rarity":
                    child.GetComponent<Text>().text = rarity.ToString();
                    break;
                case "AbilityText":
                    child.GetComponent<Text>().text = abilityTextFinal;
                    break;
                case "FlavorText":
                    child.GetComponent<Text>().text = flavorTextFinal;
                    break;
                default:
                    break;
            }
        }
        DefineColors();
        DefineRarity();
    }
}
