using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GPSController : MonoBehaviour
{
    //  public GameObject cube;

    //  public GameObject compassNeedle;

    string message = "Initializing GPS...";
    float thisLat;
    float thisLong;
    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
    public static float distance = 0;
    public static float heading = 0;

    float startLat, startLong;

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
                "\nHorizontal Accuracy: " + Input.location.lastData.horizontalAccuracy +
                "\nVertical Accuracy: " + Input.location.lastData.verticalAccuracy +
                "\n======\nHeading" + Input.compass.trueHeading;

            startLat = Input.location.lastData.latitude;
            startLong = Input.location.lastData.longitude;
        }

        //  Stop service if there is no need to query location updates continuously
        //  Input.location.Stop();
    }

    float Haversine(float lat1, float long1, float lat2, float long2)
    {
        float earthRadius = 6371000;
        float lRad1 = lat1 * Mathf.Deg2Rad;
        float lRad2 = lat2 * Mathf.Deg2Rad;
        float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dLong = (long2 - long1) * Mathf.Deg2Rad;

        float a = Mathf.Sin(dLat / 2.0f) * Mathf.Sin(dLat / 2.0f) +
            Mathf.Cos(lRad1) * Mathf.Cos(lRad2) *
            Mathf.Sin(dLong / 2.0f) * Mathf.Sin(dLong / 2.0f);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        return earthRadius * c; //  in meters
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

        distance = Haversine(startLat, startLong, thisLat, thisLong);
        heading = Input.compass.trueHeading;

        //  compassNeedle.transform.localRotation = Quaternion.Euler(0, 0, heading);

        /* message = "Current Lat: " + thisLat +
            "\nCurrent Long: " + thisLong +
            "\nUpdate Time: " + lastUpdate.ToString("HH:mm:ss") +
            "\nNow: " + rightNow.ToString("HH:mm:ss");
        */

        message = "Distance: " + distance +
            "\nHeading: " + heading +
            "\nUpdate Time: " + lastUpdate.ToString("HH:mm:ss") +
            "\nNow: " + rightNow.ToString("HH:mm:ss") + 
            "\nOutputDirection" + SwapDirection.outputDirection;

        /*
        if (thisLong >= 77.4363)
            //  show cube
            cube.SetActive(true);
        else
            cube.SetActive(false);
        */
    }
}
