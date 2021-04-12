using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeliSpecial : MonoBehaviour
{
    public GameObject missileLauncherL; //enemy bullet prefab
    public GameObject missileLauncherR; //enemy bullet prefab

    public GameObject attackHeliMissiles;
    float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer <= 0f)
        {
            attackTimer = 5.0f;
        }
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                fireMissiles();
            }
        }
        
    }

    //function to fire bullet
    void fireMissiles()
    {
        //Get a reference to the player's jet
        GameObject playerJet = GameObject.Find("F-78 Lum");

        if (playerJet != null) //if player not dead
        {
            //Instantiate an boss missiles on the left
            GameObject missiles1 = (GameObject)Instantiate(attackHeliMissiles);

            //set the missle's initial position
            missiles1.transform.position = missileLauncherL.transform.position;

            //compute the missle's direction towards the player
            Vector2 directionL = playerJet.transform.position - missiles1.transform.position;

            //set the missle direction 
            missiles1.GetComponent<EnemyBullet>().SetDirection(directionL);

            //Instantiate an player missiles on the right
            GameObject missiles2 = (GameObject)Instantiate(attackHeliMissiles);

            //set the missle's initial position
            missiles2.transform.position = missileLauncherR.transform.position;

            //compute the missle's direction towards the player
            Vector2 directionR = playerJet.transform.position - missiles2.transform.position;

            //set the missle direction 
            missiles2.GetComponent<EnemyBullet>().SetDirection(directionR);
        }
    }
}
