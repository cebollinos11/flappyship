using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int maxBullets,maxtime;
    [HideInInspector]    
    public int currentBullets,score,bestScore;

    [HideInInspector]
    public float currentTime;

    bool isPreparedToEnd;

    public UIManager ui;

    [SerializeField]
    GameObject pointsPrefab;

    bool timerActive;
    [SerializeField]
    int ExtraTimeBonus;

    CameraShaker camShaker;
    GameSounds gsounds;

    
    

	// Use this for initialization
	void Start () {
        ui = GameObject.FindObjectOfType<UIManager>();
        gsounds = GetComponent<GameSounds>();

        InitGame();
        camShaker = GameObject.FindObjectOfType<CameraShaker>();
        
	}

    bool CheckForBestScore()
    {
        if (score >= bestScore)
        {
            bestScore = score;
            return true;
        }

        return false;
            

    }
	

    public void InitGame()
    {
        Time.timeScale = 1f;
        ui.HideResults();

        currentTime = maxtime;
        timerActive = true;
        score = 0;
        currentBullets = maxBullets;
        isPreparedToEnd=false;

        spaceship[] ships = GameObject.FindObjectsOfType<spaceship>();

        for (int i = 0; i < ships.Length; i++)
        {
            Destroy(ships[i].gameObject);
        }

        timerActive = true;
        AudioManager.PlayClip(gsounds.s_PrepareToEngage,1.0f);

    }

    void EndGame()
    {
        AudioManager.PlayClip(gsounds.GameOver, 1f);
        CheckForBestScore();
        ui.ShowResults();
        ui.HideReload();
        Time.timeScale = 0f;
        
    }

    public void prepareToEnd(){

        if (isPreparedToEnd)
            return;

        isPreparedToEnd = true;
        Invoke("EndGame", 0.1f);

    }

    public void AddScore(int n,Vector3 where)
    {

        camShaker.ShakeScreen();
        score += n;

        GameObject go =(GameObject) Instantiate(pointsPrefab, where, Quaternion.identity);
        go.GetComponent<PointsParticle>().SetNumber(n);

        if(n>=50)
        {
            currentTime += ExtraTimeBonus;
            ui.ShowExtraTime();
            AudioManager.PlayClip(gsounds.Combo, 1f);
        }
    }


	// Update is called once per frame
	void Update () {


	    if(timerActive)
        {
            

            currentTime -= Time.deltaTime;

            if(currentTime<0)
            {
                currentTime = 0;
                timerActive = false;
                prepareToEnd();
            }
        }
	}
}
