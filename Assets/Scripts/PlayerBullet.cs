using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get bullets current position
        Vector2 position = transform.position;

        //compute the bullet's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update bullet's position
        transform.position = position;

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.88f));

        //if bullet went outside the screen on the top. then destroy bullet.
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player with enemy fighter
        if (col.tag == "EnemyJet" || col.tag == "Boss")
        {
            Destroy(gameObject); //Destroy bullet
        }

    }
}
