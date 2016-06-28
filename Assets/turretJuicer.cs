using UnityEngine;
using System.Collections;

public class turretJuicer : MonoBehaviour {

    [SerializeField]
    GameObject Base;

    GameObject movablePart;

	// Use this for initialization
	void Start () {
        movablePart = GetComponent<turretController>().movablePart;
	}
	
	// Update is called once per frame
	void Update () {
        float angle = movablePart.transform.localEulerAngles.x;
       
        if (angle > 180)
            angle =  angle-360;


        
        Base.transform.localEulerAngles = new Vector3(0,0,angle/2);
	}
}
