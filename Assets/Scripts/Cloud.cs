using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public float speed; //speed of the star


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current position of the cloud
        Vector2 position = transform.position;

        //Compute the cloud's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //Update the cloud's position
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //If cloud goes outside the screen on the bottom,
        //then position the cloud on the top edge of the screen
        //and randomly between the left and right side of the screen.
        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
