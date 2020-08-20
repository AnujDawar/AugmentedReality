using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject gameObject;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 0, 1f);
	}

    void Spawn()
    {
        Instantiate(gameObject, this.transform.position, this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
