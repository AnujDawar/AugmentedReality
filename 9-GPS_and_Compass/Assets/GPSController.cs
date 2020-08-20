using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GPSController : MonoBehaviour
{
    public GameObject cube;

    string message = "Initializing GPS...";
    float thisLat;
    float thisLong;
    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(30, 30, 1000, 1000), message);
    }

    IEnumerator StartGPS() 
    {
        message = "Starting";

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            message = "Location Services not Enabled";
            yield break;
        }

        // Start service before querying location
        Input.location.Start(5, 0);     //  accuracy, displacement

        // Wait until service initializes
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            message = "Timed out";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            message = "Unable to determine device location";
            yield break;
        }
        else
        {
            Input.compass.enabled = true;

            // Access granted and location value could be retrieved
            message = "Latitude: " + Input.location.lastData.latitude + 
                "\nLong: " + Input.location.lastData.longitude + 
                "\nAltitude: " + Input.location.lastData.altitude + 
                "\nHorizontal nAccuracy: " + Input.location.lastData.horizontalAccuracy +
                "\nVertical nAccuracy: " + Input.location.lastData.verticalAccuracy +
                "\n======\nHeading" + Input.compass.trueHeading;
        }

        // Stop service if there is no need to query location updates continuously
        //  Input.location.Stop();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(StartGPS());
	}
	
	// Update is called once per frame
	void Update ()
    {
        DateTime lastUpdate = epoch.AddSeconds(Input.location.lastData.timestamp);
        DateTime rightNow = DateTime.Now;

        thisLat = Input.location.lastData.latitude;
        thisLong = Input.location.lastData.longitude;

        message = "Current Lat: " + thisLat +
            "\nCurrent Long: " + thisLong +
            "\nUpdate Time: " + lastUpdate.ToString("HH:mm:ss") +
            "\nNow: " + rightNow.ToString("HH:mm:ss");
	}
}
