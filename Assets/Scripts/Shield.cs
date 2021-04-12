using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	public GameObject shieldObj;
	private int shieldCountBeforeDestroy = 0;
    public GameObject Explosion; //explosion prefab

    public static Shield shield;
    public static bool shieldActive = false;
    private SFXManager sfx;

    void Awake()
    {
        if (shield == null)
        {
            shield = GameObject.FindGameObjectWithTag("PlayerJet").GetComponent<Shield>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldActive && shieldCountBeforeDestroy > 0)
        {
            shieldObj.SetActive(true);
            shieldActive = true;
        }
        else
        {
            shieldObj.SetActive(false);
            shieldActive = false;
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect collision of player with enemy fighter or enemy bullet/missiles or boss fighter
		if ((col.tag == "EnemyJet") || (col.tag == "EnemyProjectiles") || (col.tag == "Boss"))
		{
			ExplosionEffect();
			shieldCountBeforeDestroy--;
		}

	}

    //Function to instantiate explosion
    void ExplosionEffect()
    {
        //instiantiate explosion effect
        GameObject explode = (GameObject)Instantiate(Explosion);

        //set explosion position
        explode.transform.position = transform.position;
    }

    //Function to get life points
    public static void GetShield(ShieldItem shieldCount)
    {
        shield._GetShield(shieldCount);
    }

    public void _GetShield(ShieldItem shieldCount)
    {
        shieldCountBeforeDestroy = shieldCount.maxShield;
        shieldActive = true;
        sfx.powerUps.Play();
    }
}
