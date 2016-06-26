using UnityEngine;
using System.Collections;

public class oscillateShip : MonoBehaviour {

   

    float speed, amplitude;

	// Use this for initialization
	void Start () {
        speed = 1f;
        amplitude = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Mathf.Cos(Time.time * speed) * amplitude);
	}
}
