using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeliBoss : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;
        private int _curHealth;
        public int currentHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            currentHealth = maxHealth;
        }
    }

    [SerializeField]
    private BossHealth statsInd;
    private bool flashActive;
    public float flashLength;
    private float flashCounter;
    public EnemyStats stats = new EnemyStats();
    private SpriteRenderer enemySprite;

    public Rigidbody2D boss;

    public float moveSpeed = 15f;

    public bool changeDirection = false;

    public static bool startBoss = false;
    public static bool isBossDead = false;

    public GameObject Explosion; //explosion prefab

    public GameObject GameManagerObj;//reference to Game Maanger
    private SFXManager sfx;

    void Awake()
    {
        if (MainMenuButtons.easyMode)
        {
            stats.maxHealth = 80;
            stats.Init();
        }
        else if(MainMenuButtons.mediumMode){
            stats.Init();
        }else if (MainMenuButtons.hardMode)
        {
            stats.maxHealth = 120;
            stats.Init();
        }
        else
        {
            stats.Init();
        }
        
        if (statsInd != null)
        {
            statsInd.SetHealth(stats.currentHealth, stats.maxHealth);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boss = this.gameObject.GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyKillCount.canStartBoss)
        {
            startBoss = true;
            if (startBoss)
            {
                moveEnemy();
            }
        }

        if (flashActive)
        {

            if (flashCounter > flashLength * 2.64f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 2.31)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 1.98f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 1.65f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 1.32f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * 0.66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0.0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

    }

    public void moveEnemy()
    {
        if (changeDirection == true)
        {
            boss.velocity = new Vector2(1, 0) * -1 * moveSpeed;
        }
        else if (changeDirection == false)
        {
            boss.velocity = new Vector2(1, 0) * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RightBound")
        {
            changeDirection = false;
        }

        if (col.gameObject.name == "LeftBound")
        {
            changeDirection = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player with player fighter or player bullet/missiles
        if ((col.tag == "PlayerProjectiles"))
        {
            if (!flashActive)
            {
                stats.currentHealth -= 4;
                flashActive = true;
                flashCounter = flashLength + 1.5f;
                ExplosionEffect();

                if (stats.currentHealth <= 0)
                {
                    ExplosionEffect();

                    GameManagerObj.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameWin);
                    isBossDead = true;
                    MainMenuButtons.level1 = false;
                    startBoss = false;
                    Destroy(gameObject); //Destroy enemy

                }

                if (statsInd != null)
                {
                    statsInd.SetHealth(stats.currentHealth, stats.maxHealth);
                }
            }

        }
        else if ((col.tag == "PlayerMissiles"))
        {
            if (!flashActive)
            {
                stats.currentHealth -= 10;
                flashActive = true;
                flashCounter = flashLength + 1.5f;
                ExplosionEffect();

                if (stats.currentHealth <= 0)
                {
                    ExplosionEffect();

                    GameManagerObj.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameWin);
                    isBossDead = true;
                    MainMenuButtons.level1 = false;
                    startBoss = false;
                    Destroy(gameObject); //Destroy enemy

                }

                if (statsInd != null)
                {
                    statsInd.SetHealth(stats.currentHealth, stats.maxHealth);
                }
            }
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
