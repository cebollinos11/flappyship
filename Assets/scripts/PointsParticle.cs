using UnityEngine;
using System.Collections;

public class PointsParticle : MonoBehaviour {

    [SerializeField]
    float TimeToLive;

    float t;


    public void SetNumber(int n)
    {
        TextMesh tm = GetComponent<TextMesh>();
        tm.text = n.ToString();
        tm.fontSize += n/2;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }


	// Use this for initialization
	void Start () {
        t = 0f;
        Invoke("DestroySelf", TimeToLive);
	
	}
	
	// Update is called once per frame
	void Update () {
        t+=Time.deltaTime;

        if(t>TimeToLive/2)
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, 0.1f);
	
	}
}
