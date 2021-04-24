using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour
{
    public GameObject shieldObj;
    private int shieldCountBeforeDestroy = 50;
    public GameObject Explosion; //explosion prefab

    public static bool bossShieldActive = false;

    private SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyingFortress.startBoss && shieldCountBeforeDestroy > 0)
        {
            shieldObj.SetActive(true);
            bossShieldActive = true;
        }
        else
        {
            shieldObj.SetActive(false);
            bossShieldActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of shield with player projectiles
        if ((col.tag == "PlayerProjectiles" || col.tag == "PlayerMissiles") && bossShieldActive)
        {
            ExplosionEffect();
            shieldCountBeforeDestroy--;
        }

    }

    //Function to instantiate explosion
    void ExplosionEffect()
    {
        sfx.explosion.Play();
        //instiantiate explosion effect
        GameObject explode = (GameObject)Instantiate(Explosion);

        //set explosion position
        explode.transform.position = transform.position;
    }
}
