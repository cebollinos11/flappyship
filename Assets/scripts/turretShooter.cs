using UnityEngine;
using System.Collections;

public class turretShooter : MonoBehaviour {

    [SerializeField]
    GameObject missilePrefab;

    GameManager gm;


    void Shoot()
    {

        if(gm.currentBullets>0)
        {

            gm.currentBullets--;
            GameObject mi;
            mi = (GameObject)Instantiate(missilePrefab, transform.position, transform.rotation);

            if(gm.currentBullets<1)
                gm.prepareToEnd();
        }

        else
        {
            
        }

        
    }

	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
	
	}
}
