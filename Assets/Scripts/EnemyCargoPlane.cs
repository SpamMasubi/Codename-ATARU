using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCargoPlane : MonoBehaviour
{
    float speed; //for enemy speed
    public GameObject Explosion; //explosion prefab
    public bool drops;
    public GameObject[] itemsDrop;
    public Transform dropPoint;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6.5f; //set speed

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

            //drop items
            if (drops)
            {
                int itemRandom = Random.Range(0, itemsDrop.Length);
                Instantiate(itemsDrop[itemRandom], dropPoint.position, dropPoint.rotation);
            }

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
