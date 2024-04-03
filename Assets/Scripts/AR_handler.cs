using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class AR_handler : MonoBehaviour
{
    [SerializeField]
    GameObject placedPrefab;

    ARRaycastManager raycastManager;
    bool planeInstantiated = false;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!planeInstantiated && raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;

            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);

            planeInstantiated = true;

            // Disable plane detection after plane is instantiated
            raycastManager.enabled = false;
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
}