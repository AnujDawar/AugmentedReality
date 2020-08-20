using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;

public class BeerDropSpawner : MonoBehaviour {

    public GameObject beerDrop;
    
    void Spawn()
    {
        GameObject beerDropObj = Instantiate(beerDrop, this.transform.position, Quaternion.identity);
        beerDropObj.transform.parent = this.transform;
    }

    public void OnTargetFound(ImageTarget target)
    {
        InvokeRepeating("Spawn", 0, 0.5f);
    }

    public void OnTargetLost(ImageTarget target)
    {
        CancelInvoke("Spawn");
    }
}
