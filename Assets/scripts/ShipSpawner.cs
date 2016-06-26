using UnityEngine;
using System.Collections;

public class ShipSpawner : MonoBehaviour {

    BoxCollider2D spawnBox;
    [SerializeField]
    GameObject SpaceshipPrefab;
    float t;
    [SerializeField] float spawnFreq,burstFreq;
    [SerializeField]
    int spawnLayers;

	// Use this for initialization
	void Start () {
        spawnBox = GetComponent<BoxCollider2D>();
        Debug.Log(spawnBox.bounds.max);
        SpawnShip();
        t = 0f;
	}

    void SpawnShip()
    {
        Vector3 randomSpot;
        Quaternion orientation;
        

        //pick spawn height
        //randomSpot.y = (int) Random.Range(spawnBox.bounds.max.y, spawnBox.bounds.min.y);

        int dice = Random.Range(0, spawnLayers);

        randomSpot.y = Mathf.Lerp(spawnBox.bounds.max.y, spawnBox.bounds.min.y, (float)dice / (float)spawnLayers);


        //end


        randomSpot.z = 0;

        if(Random.Range(0,100)>50)
        {
            //spawn from left
            randomSpot.x = spawnBox.bounds.min.x;
            orientation = Quaternion.Euler(0, 90, 0);
        }

        else
        {
            //Spawn from right
            randomSpot.x = spawnBox.bounds.max.x;
            orientation = Quaternion.Euler(0, -90, 0);

        }




        Instantiate(SpaceshipPrefab, randomSpot, orientation);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnShip();
        }

        t += Time.deltaTime;

        if(t>spawnFreq)
        {
            t = 0f;

            SpawnShip();

            if(Random.Range(0,100)<burstFreq)
            {
                for (int i = 0; i < 4; i++)
                {
                    SpawnShip();

                }
            }
        }

        
	
	}
}
