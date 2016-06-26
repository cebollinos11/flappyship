using UnityEngine;
using System.Collections;

public class turretController : MonoBehaviour {

    [SerializeField]
    float horizontalSpeed,verticalSpeed;


	// Use this for initialization
	void Start () {
	
	}


    void TurnHorizontal(float d)
    {
        transform.Rotate(new Vector3(0, horizontalSpeed * d * Time.timeScale, 0),Space.World);
    }

    void TurnVertical(float d)
    {
        Quaternion old = transform.rotation;
        transform.Rotate(new Vector3(verticalSpeed * d * Time.timeScale,0, 0));
        /*
         * if (transform.rotation.eulerAngles.x < 300f)
            transform.rotation = old;
         * */
    }


	// Update is called once per frame
	void Update () {

        float dx,dy;
        dx = Input.GetAxis("Horizontal");
        dy = Input.GetAxis("Vertical");

        if (dx != 0f)
        {
            TurnVertical(dx);
        }

        /*
        if(dy!=0f)
        {
            TurnVertical(dy);
        }*/

        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
	
	}
}
