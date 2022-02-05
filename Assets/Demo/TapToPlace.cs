using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{

    public GameObject placementIndicator;
    public ARRaycastManager rayCastMgr;
    //public GameObject objectToPlace;
    //private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    [HideInInspector] public static Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rayCastMgr = FindObjectOfType<ARRaycastManager>();
        //arOrigin = FindObjectOfType<ARSessionOrigin>();

        ObjectLibrary.instance.GenerateLibrary();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();


        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    PlaceObject();
        //}
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        //arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, TrackableType.Planes);
        rayCastMgr.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.main.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
             placementIndicator.SetActive(false);
        }
    }

    public void PlaceObject(GameObject objectToPlace)
    {
        counter = counter + 1;
        GameObject obj = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        objects.Add(objectToPlace.name + counter.ToString(), obj);
    }

}
