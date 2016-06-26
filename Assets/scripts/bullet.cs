using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    AnimationCurve DropRotationCurve;

    float t;

    [SerializeField]
    bool hasDump;

    bool dumpingEnabled;

    [SerializeField] float timeToDrop;
    [SerializeField]float timeToLive = 1f;

    public int multiplier = 1;

	// Use this for initialization
	void Start () {
        t = 0;

	
	}

    public void SetMultiplier(int i)
    {

        
        multiplier = i;
        TrailRenderer tr = GetComponent<TrailRenderer>();

        switch (i)
        {
            case 2:
                tr.materials[0].color = Color.red;
                break;
            case 3:
                tr.materials[0].color = Color.blue;
                break;
            case 4:
                tr.materials[0].color = Color.yellow;
                break;
            case 5:
                tr.materials[0].color = Color.white;
                break;
            case 6:
                tr.materials[0].color = Color.black;
                break;
            default:
                break;
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;

        if(hasDump)
        {
            
            if (!dumpingEnabled)
            {
                if (t > timeToDrop)
                {
                    dumpingEnabled = true;
                    t = 0;
                }

            }
            else
            {
                float newAngleX = DropRotationCurve.Evaluate(t / 2f);
                //transform.rotation = Quaternion.Euler(newAngleX * 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.rotation.eulerAngles.x, 90, newAngleX), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            }
        }
        
        
        


        transform.position += transform.forward * Time.deltaTime * maxSpeed;

        if (t > timeToLive)
        {
            Destroy(gameObject);
        }

	}

    void OnTriggerEnter(Collider col)
    {
        //return;
        spaceship ship = col.gameObject.GetComponent<spaceship>();
        if(ship!=null)
        {
            bool destroylater =false;
            if (!ship.alreadyDestroyed)
                destroylater = true;
            ship.DestroySelf(multiplier);

            if(destroylater)
                Destroy(gameObject);
        }
    }
}
