using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCargoSpawner : MonoBehaviour
{
    public GameObject CargoEnemyPlanes; //this is our enemy prefabs

    float maxSpawnRateInSeconds = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to spawn enemy

    void CargoSpawn()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Instantiate Cargo Planes Fighters
        GameObject cargoPlane = (GameObject)Instantiate(CargoEnemyPlanes);
        cargoPlane.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //Schedule when to spawn next jet
        ScheduleToSpawn();
    }

    void ScheduleToSpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1.0f)
        {
            //pick a number between 1 and maxSpawnRateInSeconds
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1.0f;
        }

        Invoke("CargoSpawn", spawnInSeconds);
    }

    //Increase difficulty of game
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1.0f)
        {
            maxSpawnRateInSeconds--;

        }
        else if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    //start enemy spawner
    public void ScheduleEnemySpawner()
    {
        //reset max spawn rate
        maxSpawnRateInSeconds = 30.0f;

        Invoke("CargoSpawn", maxSpawnRateInSeconds);

        //increase spawn rate every 3 minutes
        InvokeRepeating("IncreaseSpawnRate", 0f, 180f);
    }

    //stop enemy spawner
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("CargoSpawn");
        CancelInvoke("IncreaseSpawnRate");
    }
}
