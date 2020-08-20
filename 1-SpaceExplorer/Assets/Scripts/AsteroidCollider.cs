using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidCollider : MonoBehaviour {

    public Slider healthbar;
    public GameObject explosion;
    public GameObject explosionDeath;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Good")
        {
            healthbar.value += 10;

            if (healthbar.value >= 100)
                healthbar.value = 100;
        }
        else if(collision.gameObject.tag == "Bad")
        {
            ContactPoint contact = collision.contacts[0];

            healthbar.value -= 20;

            GameObject ex = (GameObject)Instantiate(explosion, contact.point, this.transform.rotation);
            Destroy(ex, 2f);

            if (healthbar.value <= 0)
            {
                GameObject exDeath = (GameObject)Instantiate(explosionDeath, this.transform.position, this.transform.rotation);
                Destroy(exDeath, 2f);
                Destroy(this.gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
