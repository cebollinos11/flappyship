using UnityEngine;
using System.Collections;

public class spaceship : MonoBehaviour {

    [SerializeField]
    float maxSpeed,minSpeed;
    float speed;
    Rigidbody rb;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    int bulletsToinstantiate;
    [HideInInspector]
    public bool alreadyDestroyed;
    GameManager gm;

    [SerializeField]
    GameObject SmokeParticles;
           


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(minSpeed, maxSpeed);

        gm = GameObject.FindObjectOfType<GameManager>();
	}

    public void DestroySelf(int multiplier)
    {
        if (alreadyDestroyed)
            return;
        alreadyDestroyed = true;
        GenerateBullets(multiplier+1);
        rb.isKinematic = false;
        this.enabled = false;
        rb.AddForce(transform.forward * 200f);
        rb.AddTorque(new Vector3(100f, 0, 100f));
        gm.AddScore(10*multiplier, transform.position);


        // SMOKE PARTICLE EFFECT
        GameObject go = (GameObject)Instantiate(SmokeParticles, transform.position+Vector3.up, transform.rotation);
        go.transform.parent = transform;
        //go.transform.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1);

         

        //Destroy(this.gameObject);
    }

    void GenerateBullets(int multiplier)
    {
        GameObject bu;

        for (int i = 0; i < bulletsToinstantiate; i++)
        {
            float curAngle = i * 360 / bulletsToinstantiate;
            bu = (GameObject)Instantiate(bullet, transform.position, Quaternion.Euler(curAngle,90,0));
            bu.GetComponent<bullet>().multiplier = multiplier;
        }

    }
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * Time.deltaTime * speed;	    
	    if(Input.GetKeyDown(KeyCode.Z))
        {
            DestroySelf(0);
        }

        
    
    }

    
}
