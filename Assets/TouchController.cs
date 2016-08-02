using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    turretController turCorntroller;
    turretShooter turShoot;

	// Use this for initialization
	void Start () {
        turCorntroller = GetComponent<turretController>();
        turShoot = GetComponent<turretShooter>();

	}

    void TouchShoot(Vector2 pos)
    {
        //aim

        Vector3 worldPoint;
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3( pos.x,pos.y, -Camera.main.transform.position.z));
        //,turCorntroller.movablePart.transform.position.z
        Debug.Log(pos);
        Debug.Log(worldPoint);
        turCorntroller.movablePart.transform.LookAt(worldPoint);
        //shoot
        turShoot.Shoot();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            TouchShoot(Input.mousePosition);
        }
	    
	}
}
