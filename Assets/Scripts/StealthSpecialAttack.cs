using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthSpecialAttack : MonoBehaviour
{
    public Transform lazerGun;
    public GameObject lazerBullet;
    float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        lazerGun = this.gameObject.transform;
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
                Instantiate(lazerBullet, lazerGun.position, Quaternion.identity);
            }
            
        }
    }
}
