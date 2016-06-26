﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int maxBullets,maxtime;
    [HideInInspector]    
    public int currentBullets,score;

    [HideInInspector]
    public float currentTime;

    bool isPreparedToEnd;

    UIManager ui;

    [SerializeField]
    GameObject pointsPrefab;

    bool timerActive;

	// Use this for initialization
	void Start () {
        ui = GameObject.FindObjectOfType<UIManager>();
        InitGame();
	}
	

    public void InitGame()
    {

        ui.HideResults();

        currentTime = maxtime;
        timerActive = true;
        score = 0;
        currentBullets = maxBullets;
        isPreparedToEnd=false;

        spaceship[] ships = GameObject.FindObjectsOfType<spaceship>();

        for (int i = 0; i < ships.Length; i++)
        {
            //Destroy(ships[i].gameObject);
        }

        timerActive = true;

    }

    void EndGame()
    {
        ui.ShowResults();
    }

    public void prepareToEnd(){

        if (isPreparedToEnd)
            return;

        isPreparedToEnd = true;
        Invoke("EndGame", 3f);

    }

    public void AddScore(int n,Vector3 where)
    {
        score += n;

        GameObject go =(GameObject) Instantiate(pointsPrefab, where, Quaternion.identity);
        go.GetComponent<PointsParticle>().SetNumber(n);
    }


	// Update is called once per frame
	void Update () {


	    if(timerActive)
        {
            Debug.Log("current time set to " + currentTime.ToString());

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
