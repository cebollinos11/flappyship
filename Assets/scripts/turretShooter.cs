﻿using UnityEngine;
using System.Collections;

public class turretShooter : MonoBehaviour {

    [SerializeField]
    GameObject missilePrefab;

    GameManager gm;

    public float reloadTime;
    bool isReloading;

    [SerializeField] AudioClip soundShoot;

    turretController turretController;
    

    IEnumerator ReloadCoroutine()
    {
        gm.ui.ShowReload();
        yield return new WaitForSeconds(reloadTime);
        gm.currentBullets = gm.maxBullets;
        isReloading = false;
        gm.ui.HideReload();
    }


    public void Shoot()
    {

        if(gm.currentBullets>0)
        {

            gm.currentBullets--;
            GameObject mi;
            mi = (GameObject)Instantiate(missilePrefab, turretController.movablePart.transform.position, turretController.movablePart.transform.rotation);
            AudioManager.PlayClip(soundShoot,0.5f);

            /*if(gm.currentBullets<1)
                gm.prepareToEnd();
             * */
        }

        else
        {
            if (!isReloading)
            {
                isReloading = true;
                StartCoroutine(ReloadCoroutine());
            }
        }

        
    }

	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
        turretController = GetComponent<turretController>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
	
	}
}
