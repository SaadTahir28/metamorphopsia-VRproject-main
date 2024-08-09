using UnityEngine;
using ViveSR.anipal.Eye; // Importing the namespace for the Vive Eye Tracker SDK.

[System.Serializable]
public class GazeData
{
    [SerializeField]
    public float timestamp;
    [SerializeField]
    public Vector2 leftEyeData;
    [SerializeField]
    public float leftEyeOpenness;
    [SerializeField]
    public Vector2 rightEyeData;
    [SerializeField]
    public float rightEyeOpenness;
    [SerializeField]
    public Vector2 bothEyeData;

    public GazeData(float timestamp, Vector2 leftData, float leftOpenness, Vector2 rightData, float rightOpenness, Vector2 bothData)
    {
        this.timestamp = timestamp;
        this.leftEyeData = leftData;
        this.leftEyeOpenness = leftOpenness;
        this.rightEyeData = rightData;
        this.rightEyeOpenness = rightOpenness;
        this.bothEyeData = bothData;
    }
}