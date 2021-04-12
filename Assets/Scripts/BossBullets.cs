using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{

    public Rigidbody2D bullet;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = new Vector2(0, -1) * speed;
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
