using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    private int attack;

    // Start is called before the first frame update
    void Start()
    {
        this.attack = GetComponent<CardScript>().attack;
    }

    public void Attack (GameObject enemy)
    {
        CardScript enemyScript = enemy.GetComponent<CardScript>();
        enemyScript.health -= attack;
        enemyScript.UpdateValues();
        enemyScript.CheckForDeath();
    }
}
