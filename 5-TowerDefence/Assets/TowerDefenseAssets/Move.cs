using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 0.5f;
    public float turnSpeed = 1f;
    GameObject home;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("FindHome", 0, 1);
	}

    void FindHome()
    {
        home = GameObject.FindWithTag("home");

        if (home != null)
            CancelInvoke();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "home")
        {
            Destroy(this.gameObject, 1);
            this.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (home != null)
        {
            Vector3 direction = home.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.smoothDeltaTime);
        }

        this.gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
