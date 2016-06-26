using UnityEngine;
using System.Collections;

public class RestartGameUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.FindObjectOfType<GameManager>().InitGame();
        }
	
	}
}
