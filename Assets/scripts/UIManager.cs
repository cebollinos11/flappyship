using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    Text Bullets, Score, SummaryScore, Time,SummaryBestScore;

    [SerializeField]GameObject LevelSummary;

    GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
	
	}

    public void HideResults()
    {
        LevelSummary.SetActive(false);
    }
    public void ShowResults()
    {
        LevelSummary.SetActive(true);
        SummaryScore.text = gm.score.ToString();
        SummaryBestScore.text = gm.bestScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        Bullets.text = gm.currentBullets.ToString();
        Score.text = gm.score.ToString();
        Time.text = ((int) (gm.currentTime)).ToString();

        
	
	}
}
