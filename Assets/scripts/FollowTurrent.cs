using UnityEngine;
using System.Collections;

public class FollowTurrent : MonoBehaviour {

    GameObject turret;
	// Use this for initialization
	void Start () {
        Debug.Log("init cam");
        turret = (GameObject)GameObject.FindObjectOfType<turretController>().gameObject;
        transform.parent = turret.transform;
        Debug.Log("parenting" + turret.transform.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
