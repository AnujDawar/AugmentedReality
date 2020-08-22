using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapDirection : MonoBehaviour
{
    public GameObject North;
    public GameObject South;
    public GameObject East;
    public GameObject West;

    public static string outputDirection = "";

    GameObject NorthObj, SouthObj, EastObj, WestObj;

    // Use this for initialization
    void Start ()
    {
        NorthObj = Instantiate(North, North.transform.position, Quaternion.identity);
        SouthObj = Instantiate(South, South.transform.position, Quaternion.identity);
        EastObj = Instantiate(East, East.transform.position, Quaternion.identity);
        WestObj = Instantiate(West, West.transform.position, Quaternion.identity);

        NorthObj.transform.parent = this.transform;
        SouthObj.transform.parent = this.transform;
        EastObj.transform.parent = this.transform;
        WestObj.transform.parent = this.transform;

        NorthObj.SetActive(false);
        SouthObj.SetActive(false);
        EastObj.SetActive(false);
        WestObj.SetActive(false);
    }

	// Update is called once per frame
	void Update ()
    {
	    if((GPSController.heading > 0 && GPSController.heading <= 10) || (GPSController.heading >= 350 && GPSController.heading < 360))
        {
            outputDirection = "N";

            NorthObj.SetActive(true);
            SouthObj.SetActive(false);
            EastObj.SetActive(false);
            WestObj.SetActive(false);
        }
        else if (GPSController.heading > 170 && GPSController.heading <= 190)
        {
            outputDirection = "S";

            NorthObj.SetActive(false);
            SouthObj.SetActive(true);
            EastObj.SetActive(false);
            WestObj.SetActive(false);
        }
        else if (GPSController.heading > 80 && GPSController.heading <= 110)
        {
            outputDirection = "E";

            NorthObj.SetActive(false);
            SouthObj.SetActive(false);
            EastObj.SetActive(true);
            WestObj.SetActive(false);
        }
        else if (GPSController.heading > 260 && GPSController.heading <= 280)
        {
            outputDirection = "W";

            NorthObj.SetActive(false);
            SouthObj.SetActive(false);
            EastObj.SetActive(false);
            WestObj.SetActive(true);
        }
        else
        {
            outputDirection = "";

            NorthObj.SetActive(false);
            SouthObj.SetActive(false);
            EastObj.SetActive(false);
            WestObj.SetActive(false);
        }
    }
}
