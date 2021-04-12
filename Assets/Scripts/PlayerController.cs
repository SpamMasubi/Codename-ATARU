using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject GameManagerObj;//reference to Game Maanger
	private SFXManager sfx;
	public GameObject playerMisslesL;
	public GameObject playerMisslesR;
	public GameObject playerMissiles;

	public static PlayerController playerControl;

	public GameObject bullet;//bullet prefab
	public GameObject bulletPosition;
	public GameObject Explosion; //explosion prefab

	public Text LivesUI; //refrence to lives ui text
	const int maxLives = 3; //maximum lives of player
	private static int lives; //current player's lives
	public static int playerLives
	{
		get { return lives; }
	}

	public Text MissilesText;
	const int maxMissiles = 3;
	private static int missilesInventory;
	public static int missilesStocks
	{
		get { return missilesInventory; }
	}

	public float speed;
	private bool isFiring;
	bool stopFiring;

	public GameObject circle;
	public GameObject outerCircle;
	private Vector2 startingPoint;
	private int leftTouch = 99;

	private bool flashActive;
	public float flashLength;
	private float flashCounter;
	private SpriteRenderer playerSprite;

	void Awake()
	{
		if (playerControl == null)
		{
			playerControl = GameObject.FindGameObjectWithTag("PlayerJet").GetComponent<PlayerController>();
		}
	}

	public void Init()
	{
		lives = maxLives;

		//Update the lives UI text
		LivesUI.text = lives.ToString();

		//reset our player jet to original position
		transform.position = new Vector2(0, -9);

		//set this player game object to active
		gameObject.SetActive(true);

		missilesInventory = maxMissiles;

		//Update the Missiles UI text
		MissilesText.text = missilesInventory.ToString();

	}

	public void ContinueInit()
	{
		//reset our player jet to original position
		transform.position = new Vector2(0, -9);

		//set this player game object to active
		gameObject.SetActive(true);
		//Update the lives UI text
		LivesUI.text = lives.ToString();
		//Update the Missiles UI text
		MissilesText.text = missilesInventory.ToString();

	}



	// Use this for initialization
	void Start()
	{
		sfx= FindObjectOfType<SFXManager>();
		playerSprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
#if UNITY_STANDALONE
		//Fire bullets
		if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Z))
		{
			//play audio
			sfx.playerBullet.Play();

			GameObject playerBullet = (GameObject)Instantiate(bullet);
			playerBullet.transform.position = bulletPosition.transform.position;//set the bullet initial position
		}
		
		float x = Input.GetAxisRaw("Horizontal");//the value will be -1, 0 or 1 (for left, no input, and right)
		float y = Input.GetAxisRaw("Vertical");//the value will be -1, 0 or 1 (for down, no input, and up)

		//now based on the input we compute a direction vector, and we normalize it to get a unit vector
		Vector2 direction = new Vector2(x, y).normalized;

		//now we call the function that computes and sets the player's position
		Move(direction);
#endif

#if UNITY_ANDROID || UNITY_IOS
		if (isFiring)
		{
			makeFireVariableFalse();
			Shoot();
		}

		int i = 0;
		while (i < Input.touchCount)
		{
			Touch t = Input.GetTouch(i);
			Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
			if (t.phase == TouchPhase.Began)
			{
				/*
				if (t.position.x > Screen.width / 2)
				{
					Shoot();
				}
				else
				{
					leftTouch = t.fingerId;
					startingPoint = touchPos;
				}*/
				if (t.position.x < Screen.width / 2)
				{
					leftTouch = t.fingerId;
					startingPoint = touchPos;
				}
			}
			else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
			{
				Vector2 offset = touchPos - startingPoint;
				Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

				Move(direction);

				circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

			}
			else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
			{
				leftTouch = 99;
				circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
			}
			++i;
		}
#endif

		if (flashActive)
		{

			if (flashCounter > flashLength * 2.64f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashLength * 2.31)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > flashLength * 1.98f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashLength * 1.65f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > flashLength * 1.32f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashLength * 0.99f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > flashLength * 0.66f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else if (flashCounter > flashLength * 0.33f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			}
			else if (flashCounter > 0.0f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}
			flashCounter -= Time.deltaTime;
		}
	}

	Vector2 getTouchPosition(Vector2 touchPosition)
	{
		return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
	}

	void Move(Vector2 direction)
	{
		//find the screen limits to the player's movement (left, right, top and bottom edges of the screen)
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //this is the bottom-left point (corner) of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //this is the top-right point (corner) of the screen

		max.x = max.x - 0.225f; //subtract the player sprite half width
		min.x = min.x + 0.225f; //add the player sprite half width

		max.y = max.y - 0.285f; //subtract the player sprite half height
		min.y = min.y + 0.285f; //add the player sprite half height

		//Get the player's current position
		Vector2 pos = transform.position;

		//Calculate the new position
		pos += direction * speed * Time.deltaTime;

		//Make sure the new position is outside the screen
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		//Update the player's position
		transform.position = pos;
	}
	public void isFiringBullets()
	{
		stopFiring = false;
		makeFireVariableTrue();
	}

	public void isNotFiringBullets()
	{
		isFiring = false;
		stopFiring = true;
	}

	void makeFireVariableTrue()
	{
		isFiring = true;
	}

	void makeFireVariableFalse()
	{
		isFiring = false;
		if (stopFiring == false)
		{
			Invoke("makeFireVariableTrue", 0.2f);
		}
	}
	//Function to make player's shoot
	public void Shoot()
    {
		//play audio
		sfx.playerBullet.Play();

		GameObject playerBullet = (GameObject)Instantiate(bullet);
		playerBullet.transform.position = bulletPosition.transform.position;//set the bullet initial position
	}

	public void fireMissiles()
	{
		if (missilesInventory > 0)
		{
			//Get a reference to the enemy's jet
			GameObject enemyJet = GameObject.FindGameObjectWithTag("EnemyJet");
			GameObject boss = GameObject.FindGameObjectWithTag("Boss");

			if (enemyJet != null) //if player not dead
			{
				//Instantiate an player missiles on the left
				GameObject missiles1 = (GameObject)Instantiate(playerMissiles);

				//set the missle's initial position
				missiles1.transform.position = playerMisslesL.transform.position;

				//compute the missle's direction towards the player
				Vector2 directionL = enemyJet.transform.position - missiles1.transform.position;

				//set the missle direction 
				missiles1.GetComponent<PlayerMissles>().SetDirection(directionL);

				//Instantiate an player missiles on the right
				GameObject missiles2 = (GameObject)Instantiate(playerMissiles);

				//set the missle's initial position
				missiles2.transform.position = playerMisslesR.transform.position;

				//compute the missle's direction towards the player
				Vector2 directionR = enemyJet.transform.position - missiles2.transform.position;

				//set the missle direction 
				missiles2.GetComponent<PlayerMissles>().SetDirection(directionR);
			}
			else if (boss != null)
            {
				//Instantiate an player missiles on the left
				GameObject missiles1 = (GameObject)Instantiate(playerMissiles);

				//set the missle's initial position
				missiles1.transform.position = playerMisslesL.transform.position;

				//compute the missle's direction towards the player
				Vector2 directionL = boss.transform.position - missiles1.transform.position;

				//set the missle direction 
				missiles1.GetComponent<PlayerMissles>().SetDirection(directionL);

				//Instantiate an player missiles on the right
				GameObject missiles2 = (GameObject)Instantiate(playerMissiles);

				//set the missle's initial position
				missiles2.transform.position = playerMisslesR.transform.position;

				//compute the missle's direction towards the player
				Vector2 directionR = boss.transform.position - missiles2.transform.position;

				//set the missle direction 
				missiles2.GetComponent<PlayerMissles>().SetDirection(directionR);
			}
			missilesInventory--;
			MissilesText.text = missilesInventory.ToString();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		//Detect collision of player with enemy fighter or enemy bullet/missiles or boss fighter
		if ((col.tag == "EnemyJet") || (col.tag == "EnemyProjectiles") || (col.tag == "Boss"))
		{
			ExplosionEffect();
			if (!flashActive && lives != 0 && !Shield.shieldActive)
			{
				flashActive = true;
				flashCounter = flashLength + 1.5f;
				lives--; //subtract one life point

				//Update the lives UI text
				LivesUI.text = lives.ToString();
				if (lives == 0) //if player is dead
				{
					//Change to GameOver State
					GameManagerObj.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
					//hide player
					gameObject.SetActive(false);
				}
			}
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
	public static void GetPlayerLives(LifePoints playerLives)
	{
		playerControl._GetPlayerLives(playerLives);
	}

	public void _GetPlayerLives(LifePoints playerLives)
	{
		lives += playerLives.lifeValue;
		LivesUI.text = lives.ToString();
		sfx.player1UP.Play();
	}

	//Function to get life points
	public static void GetMissiles(MissilesIncr missilesInc)
	{
		playerControl._GetMissiles(missilesInc);
	}

	public void _GetMissiles(MissilesIncr missilesInc)
	{
		missilesInventory += missilesInc.MissilesValue;
		MissilesText.text = missilesInventory.ToString();
		sfx.powerUps.Play();
	}
}
