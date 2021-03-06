using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float nextfire = 1.0f;
    public float currentTime = 0.0f;
    private SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = this.gameObject.transform;
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyShoot(); 
    }

    public void EnemyShoot()
    {
        currentTime += Time.deltaTime;

        if(currentTime > nextfire)
        {
            nextfire += currentTime;

            sfx.enemyBullets.Play();
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);

            nextfire -= currentTime;

            currentTime = 0.0f;
        }
    }
}
