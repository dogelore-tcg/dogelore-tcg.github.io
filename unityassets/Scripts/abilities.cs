using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilities : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //stuns foe for turns
    void stunFoe(GameObject enemy, int turns)
    {
        CardScript enemyScript = enemy.GetComponent<CardScript>();
        enemyScript.updateStunTurns(turns);
        enemyScript.updateIsStun(true);
    }
    //adds turns to existing stun, or makes next stun more powerful.
    void stunAdd(GameObject enemy, int turns)
    {
        CardScript enemyScript = enemy.GetComponent<CardScript>();
        enemyScript.updateStunTurns(turns);
        
    }

    //bleeds foe for turns, dealing damage per turn.
    void bleedFoe(GameObject enemy, int turns, int damage)
    {
        CardScript enemyScript = enemy.GetComponent<CardScript>();
        //enemyScript.updateStunTurns(turns);
        //enemyScript.updateIsStun(true);
    }

    //adds turns to existing bleed, or makes next stun more powerful.
    void bleedAdd(GameObject enemy, int turns)
    {
        CardScript enemyScript = enemy.GetComponent<CardScript>();
        //enemyScript.updateStunTurns(turns);
    }


}
