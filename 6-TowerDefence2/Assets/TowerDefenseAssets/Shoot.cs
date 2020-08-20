using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject spawnPos;
    public float turnSpeed = 1f;

    GameObject goob;

	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "goober" && goob == null)
        {
            goob = col.gameObject;
            InvokeRepeating("SpawnBullet", 0, 3.0f);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject == goob)
        {
            goob = null;
            CancelInvoke("SpawnBullet");
        }
    }

    void SpawnBullet()
    {
        Instantiate(bullet, spawnPos.transform.position, spawnPos.transform.rotation);

        this.gameObject.GetComponent<AudioSource>().Play();

        if(goob.GetComponent<Move>().isDead)
        {
            goob = null;
            CancelInvoke("SpawnBullet");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(goob)
        {
            Vector3 direction = goob.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.smoothDeltaTime);
        }
	}
}
