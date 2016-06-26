using UnityEngine;
using System.Collections;

public class ShipSpawner : MonoBehaviour {

    BoxCollider2D spawnBox;
    [SerializeField]
    GameObject SpaceshipPrefab,MiniSpaceShipPrefab;
    float t;
    [SerializeField] float spawnFreq,burstFreq,miniSpaceshipChance;
    [SerializeField]
    int spawnLayers;

    [SerializeField]
    float diagonalChance;

	// Use this for initialization
	void Start () {
        spawnBox = GetComponent<BoxCollider2D>();

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

        //add change on orientation if it spawns low


        if(Random.Range(0,1.0f)<diagonalChance)
        {
            if (dice > spawnLayers / 2)
            {
                orientation = Quaternion.Euler(-10, orientation.eulerAngles.y, orientation.eulerAngles.z);
            }

            if (dice < spawnLayers / 8)
            {
                orientation = Quaternion.Euler(10, orientation.eulerAngles.y, orientation.eulerAngles.z);
            }
        }


        



        GameObject ship = SpaceshipPrefab;

        //chance for mini space ship


        if(Random.Range(0,100)<miniSpaceshipChance)
        {
            ship = MiniSpaceShipPrefab;
        }

        Instantiate(ship, randomSpot, orientation);

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
