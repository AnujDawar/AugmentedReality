using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;

public class SwitchPrefab : MonoBehaviour {

    public GameObject granny;
    public GameObject bear;
    GameObject grannyObj;
    GameObject bearObj;
    ImageTrackable trackable;

	// Use this for initialization
	void Start ()
    {
        grannyObj = Instantiate(granny, granny.transform.position, Quaternion.identity);
        grannyObj.transform.parent = this.transform;
        grannyObj.SetActive(false);

        bearObj = Instantiate(bear, bear.transform.position, Quaternion.identity);
        bearObj.transform.parent = this.transform;
        bearObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.location.lastData.longitude >= 77.43635)
        {
            bearObj.SetActive(true);
            grannyObj.SetActive(false);
        }
        else
        {
            bearObj.SetActive(false);
            grannyObj.SetActive(true);
        }
	}
}
