using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{

    private GameObject playerField;
    private GameObject enemyField;
    private GameObject previewPanel;

    public void Start()
    {
        this.playerField = GameObject.FindGameObjectWithTag("PlayerField");
        this.enemyField = GameObject.FindGameObjectWithTag("EnemyField");
        this.previewPanel = GameObject.FindGameObjectWithTag("PreviewPanel");

        previewPanel.SetActive(false);
    }

    public void SelectCard ()
    {
        previewPanel.SetActive(true);
        CardScript previewCard = GameObject.FindGameObjectWithTag("Preview").GetComponent<CardScript>();
        CardScript selectedCard = EventSystem.current.currentSelectedGameObject.GetComponent<CardScript>();

        previewCard.attack = selectedCard.attack;
        previewCard.cardArt = selectedCard.cardArt;
        previewCard.health = selectedCard.health;
        previewCard.type = selectedCard.type;
        previewCard.rarity = selectedCard.rarity;
        previewCard.cardName = selectedCard.cardName;
        previewCard.abilityText = selectedCard.abilityText;
        previewCard.flavorText = selectedCard.flavorText;
    }
    
    public void MoveToPlayField ()
    {

    }

    public void Attack ()
    {

    }
}
