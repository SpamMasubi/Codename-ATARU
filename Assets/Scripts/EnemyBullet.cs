using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; //bullet speed
    Vector2 _direction; //direction of the bullet
    bool isReady; //too know when to fire

    //set Awake function for default values
    void Awake()
    {
        speed = 20f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    //Function to set the bullet's direction.
    public void SetDirection(Vector2 direction)
    {
        //set the direction normalized, to get an unit vector
        _direction = direction.normalized;

        isReady = true; //set flag to true
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            //get the bullets current position
            Vector2 position = transform.position;

            //compute the bullet's new position 
            position += _direction * speed * Time.deltaTime;

            //update the bullet's position
            transform.position = position;

            //Remove bullet from the game if bullet goes outside the screen
            //this is the bottom-left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            //this is the top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player with player fighter
        if (col.tag == "PlayerJet" || col.tag == "Shield")
        {
            Destroy(gameObject); //Destroy bullet
        }

    }
}
