using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKillCount : MonoBehaviour
{
    Text enemyKillUI;
    int killCount;
    public GameObject GameManagerObj;

    public static bool canStartBoss = false;

    public int KillCount
    {
        get
        {
            return this.killCount;
        }
        set
        {
            this.killCount = value;
            UpdateKillTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get the Text UI component of this game object
        enemyKillUI = GetComponent<Text>();
    }

    //Function to update scores
    void UpdateKillTextUI()
    {
        if (killCount >= 0)
        {
            string enemyKilled = string.Format("{0:00}", killCount);
            enemyKillUI.text = enemyKilled;
        }
        if (killCount == 0)
        {
            canStartBoss = true;
            GameManagerObj.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Boss);
        }
    }
}
