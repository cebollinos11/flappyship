using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class blinkText : MonoBehaviour {

    float duration = 1.2f;
    float speed = 0.2f;
    float t;
    Text text;
    
	// Use this for initialization
	void Start () {
        
        
        t = speed;
        
        
	}
	
	// Update is called once per frame
	void Update () {
        t -= Time.deltaTime;
        if (t < 0)
        {
            t = speed;
            text.enabled = !text.enabled;
            
        }
	
	}
    void DisableGO()
    {
        transform.parent.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        Invoke("DisableGO", duration);
        text = GetComponent<Text>();
        text.enabled=true;
        t = speed;
    }
}
