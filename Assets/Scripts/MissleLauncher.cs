using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public GameObject playerMissles; //enemy bullet prefab

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //function to fire bullet
    void fireBullets()
    {
        //Get a reference to the enemy's jet
        GameObject enemyJet = GameObject.FindGameObjectWithTag("EnemyJet");

        if (enemyJet != null) //if player not dead
        {
            //Instantiate an enemy bullet
            GameObject missles = (GameObject)Instantiate(playerMissles);

            //set the missle's initial position
            missles.transform.position = transform.position;

            //compute the missle's direction towards the player
            Vector2 direction = enemyJet.transform.position - missles.transform.position;

            //set the missle direction 
            missles.GetComponent<PlayerMissles>().SetDirection(direction);
        }
    }
}
