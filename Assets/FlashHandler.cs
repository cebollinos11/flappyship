using UnityEngine;
using System.Collections;

public class FlashHandler : MonoBehaviour {


    MeshRenderer mr;
    bool alreadyflashing;
    spaceship spaceship;

	// Use this for initialization
	void Start () {

        mr = GetComponent<MeshRenderer>();
        spaceship = GetComponentInParent<spaceship>();
        //MakeItFlash();
	}

    void Update()
    {
        if(!alreadyflashing)
        {
            if(spaceship.alreadyDestroyed)
            {
                alreadyflashing = true;
                MakeItFlash();
            }
        }
    }


    void MakeItFlash()
    {
        mr.materials[0].SetFloat("_FlashEnabled", 1f);
    }
}
