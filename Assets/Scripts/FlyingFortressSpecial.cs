using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFortressSpecial : MonoBehaviour
{
    public Transform lazerGun;
    public GameObject lazerBullet;
    float attackTimer = 0f;
    float cannonReadyTimer = 0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lazerGun = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer <= 0f && cannonReadyTimer <= 0f)
        {
            attackTimer = 9.0f;
            cannonReadyTimer = 10.0f;
        }
        if (cannonReadyTimer > 0f)
        {
            cannonReadyTimer -= Time.deltaTime;
        }
        else
        {
            if (attackTimer > 0f && cannonReadyTimer <= 0f)
            {
                anim.SetBool("IsReady", true);
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    Instantiate(lazerBullet, lazerGun.position, Quaternion.identity);
                    anim.SetBool("IsReady", false);
                }
            }
        }
    }
}
