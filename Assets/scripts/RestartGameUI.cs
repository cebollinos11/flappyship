using UnityEngine;
using System.Collections;

public class RestartGameUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonUp(0))
        {
            GameObject.FindObjectOfType<GameManager>().InitGame();
        }
	
	}
}
