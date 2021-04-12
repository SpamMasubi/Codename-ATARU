using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySukhoi : MonoBehaviour
{
    float speed; //for enemy speed
    public GameObject Explosion; //explosion prefab
    GameObject EnemyKillCount;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8.5f; //set speed
        EnemyKillCount = GameObject.FindGameObjectWithTag("KillCount");
    }

    // Update is called once per frame
    void Update()
    {
        //Get Enemy current position
        Vector2 position = transform.position;

        //Compute the enemy's new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update enemy's new position
        transform.position = position;

        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //if the enemy went outside the screen on the bottom, then destroy the enemy
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player with player fighter or player bullet/missiles
        if ((col.tag == "PlayerJet") || (col.tag == "PlayerProjectiles") || (col.tag == "Shield"))
        {
            ExplosionEffect();

            EnemyKillCount.GetComponent<EnemyKillCount>().KillCount -= 1;

            Destroy(gameObject); //Destroy enemy
        }

    }

    //Function to instantiate explosion
    void ExplosionEffect()
    {
        //instiantiate explosion effect
        GameObject explode = (GameObject)Instantiate(Explosion);

        //set explosion position
        explode.transform.position = transform.position;
    }
}
