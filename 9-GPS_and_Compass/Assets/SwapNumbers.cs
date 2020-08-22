using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;

public class SwapNumbers : MonoBehaviour {

    public GameObject[] prefabs;
    GameObject[] prefabObs;
    ImageTrackable imageTrackable;

	// Use this for initialization
	void Start ()
    {
        prefabObs = new GameObject[prefabs.Length];

	    for(int i = 0; i < prefabs.Length; i++)
        {
            prefabObs[i] = Instantiate(prefabs[i], prefabs[i].transform.position, Quaternion.identity);
            prefabObs[i].transform.parent = this.transform;
            prefabObs[i].SetActive(false);
        }
	}

    void TurnOnObj(int id)
    {
        if (prefabObs[id].activeSelf)
            return;

        for(int i = 0; i < prefabObs.Length; i++)
        {
            if(id == i)
                prefabObs[i].SetActive(true);
            else
                prefabObs[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GPSController.distance < 3)
        {
            TurnOnObj(0);
        }
        else if (GPSController.distance < 6)
        {
            TurnOnObj(1);
        }
        else
            TurnOnObj(2);
	}
}
