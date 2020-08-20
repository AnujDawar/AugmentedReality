using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right") && this.transform.position.x <= 14.0f)
            this.transform.Translate(0.2f, 0, 0);
        else if (Input.GetKey("left") && this.transform.position.x >= -14.0f)
            this.transform.Translate(-0.2f, 0, 0);
	}
}
