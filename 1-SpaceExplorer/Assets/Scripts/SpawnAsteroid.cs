using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour {

    public GameObject asteroidObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0, 1000) <= 10)
        {
            //  1% chance
            Vector3 pos = new Vector3(
                this.transform.position.x + Random.Range(-14.0f, 14.0f), 
                this.transform.position.y, 
                this.transform.position.z);
            Instantiate(asteroidObj, pos, asteroidObj.transform.rotation);
        }
	}
}
