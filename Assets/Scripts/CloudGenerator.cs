using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    public GameObject cloud; //cloud prefabs
    public int maxClouds; //max numbers of clouds

    // Start is called before the first frame update
    void Start()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //loop to create stars
        for(int i = 0; i < maxClouds; i++)
        {
            GameObject clouds = (GameObject)Instantiate(cloud);

            //set the position of the cloud random x and random y
            clouds.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the cloud
            clouds.GetComponent<Cloud>().speed = -(1f * Random.value + 0.5f);

            //make cloud a child of the cloud generator
            clouds.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
