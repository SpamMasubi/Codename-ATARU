using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject EnemyBullet; //enemy bullet prefab

    // Start is called before the first frame update
    void Start()
    {
        //fire an enemy bullet for 1 second
        Invoke("fireBullets", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to fire bullet
    void fireBullets()
    {
        //Get a reference to the player's jet
        GameObject playerJet = GameObject.Find("F-78 Lum");

        if(playerJet != null) //if player not dead
        {
            //Instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //set the bullet's initial position
            bullet.transform.position = transform.position;

            //compute the bullet's direction towards the player
            Vector2 direction = playerJet.transform.position - bullet.transform.position;

            //set the bullet direction 
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
