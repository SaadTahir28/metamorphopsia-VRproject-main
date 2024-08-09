using UnityEngine;
using ViveSR.anipal.Eye; // Importing the namespace for the Vive Eye Tracker SDK.
using System.Text.RegularExpressions; // For using regular expressions.
using System.Collections; // For using coroutines.
using TMPro;
using System.Collections.Generic;

public class SRAnipalEyeTrackingData : MonoBehaviour // Defining a new class EyeGazeRaycast, inheriting from MonoBehaviour.
{
    public float renderDistance = 9f;
    public bool collectingData = false; // Flag to control data collection

    // List to store gaze data
    private List<GazeData> gazeDataList = new List<GazeData>();

    private void Start()
    {
        if (!SRanipal_Eye_Framework.Instance.EnableEye)
        {
            enabled = false;
            return;
        }
    }

    private void Update() // Update is called once per frame.
    {
        if(collectingData)
        {
            var timestamp = Time.time;

            float leftEyeOpenness, rightEyeOpenness;

            Vector3 binocularVector = Vector3.zero;
            Vector3 leftEyeVector = Vector3.zero;
            Vector3 rightEyeVector = Vector3.zero;

            if (SRanipal_Eye_v2.GetEyeOpenness(EyeIndex.LEFT, out leftEyeOpenness))
            {
                Debug.Log("leftEyeOpenness: " + leftEyeOpenness);
            }

            if (SRanipal_Eye_v2.GetEyeOpenness(EyeIndex.RIGHT, out rightEyeOpenness))
            {
                Debug.Log("rightEyeOpenness: " + rightEyeOpenness);
            }

            // Obtaining the combined gaze direction for both eyes and storing it in gazeRay.
            if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.COMBINE, out var gazeRay))
            {
                // Binocular
                var origin = gazeRay.origin; //eyePosition
                var dir = gazeRay.direction; //eyeRotation
                var depth = renderDistance - origin.z;
                var eyePosition = origin + depth * (dir / dir.z);
                binocularVector = new Vector3(eyePosition.x, eyePosition.y, renderDistance);
            }

            if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.LEFT, out var leftGazeRay))
            {
                // Left
                var origin = leftGazeRay.origin; //eyePosition
                var dir = leftGazeRay.direction; //eyeRotation
                var depth = renderDistance - origin.z;
                var eyePosition = origin + depth * (dir / dir.z);
                leftEyeVector = new Vector3(eyePosition.x, eyePosition.y, renderDistance);

            }

            if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.RIGHT, out var rightGazeRay))
            {
                // Right
                var origin = rightGazeRay.origin; //eyePosition
                var dir = rightGazeRay.direction; //eyeRotation
                var depth = renderDistance - origin.z;
                var eyePosition = origin + depth * (dir / dir.z);
                rightEyeVector = new Vector3(eyePosition.x, eyePosition.y, renderDistance);

            }

            var gazeData = new GazeData(timestamp, leftEyeVector, leftEyeOpenness, rightEyeVector, rightEyeOpenness, binocularVector);

            gazeDataList.Add(gazeData);

        }
    }

    public List<GazeData> GetData()
    {
        if(gazeDataList != null)
            return gazeDataList;
        return new List<GazeData>();
    }

    public void ClearData()
    {
        gazeDataList.Clear();
    }

    public void SetDataCollection(bool state)
    {
        collectingData = state;
    }
}