using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthSpecialAttack : MonoBehaviour
{
    public Transform lazerGun;
    public GameObject lazerBullet;
    float attackTimer = 0f;
    private SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        lazerGun = this.gameObject.transform;
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer <= 0f)
        {
            attackTimer = 3.0f;
        }
        if (attackTimer > 0f)
        {
            
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                sfx.laser.Play();
                Instantiate(lazerBullet, lazerGun.position, Quaternion.identity);
            }
            
        }
    }
}
