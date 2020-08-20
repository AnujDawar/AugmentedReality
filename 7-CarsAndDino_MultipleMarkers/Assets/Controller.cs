using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;

public class Controller : MonoBehaviour
{

    public ImageTracker carTracker;
    public ImageTracker dinoTracker;
    public GameObject   carPanel;
    public GameObject   dinoPanel;

    private bool isTrackerLoading = false;

	public void OnTrackCar()
    {
        if(!carTracker.enabled && !isTrackerLoading)
        {
            isTrackerLoading = true;
            carPanel.SetActive(true);
            dinoPanel.SetActive(false);
            carTracker.enabled = true;
        }
    }

    public void OnTrackDino()
    {
        if(!dinoTracker.enabled && !isTrackerLoading)
        {
            isTrackerLoading = true;
            carPanel.SetActive(false);
            dinoPanel.SetActive(true);
            dinoTracker.enabled = true;
        }
    }

    public void OnTrackerLoaded()
    {
        isTrackerLoading = false;
    }
}
