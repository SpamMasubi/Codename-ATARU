using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public int maxShield = 10;

    // Update is called once per frame
    void Update()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //if item went outside the screen on the bottom, then destroy the item
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerJet"))
        {
            Shield.GetShield(this);
            Destroy(gameObject);
        }
    }
}
