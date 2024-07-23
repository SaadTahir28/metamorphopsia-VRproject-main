using UnityEngine;

public class Webcam : MonoBehaviour
{
    public Material material;
    private WebCamTexture webcamTexture;

    private void OnEnable()
    {
        // Check for available webcams
        if (WebCamTexture.devices.Length > 0)
        {
            Debug.Log("Camera Found");
            // Use the first available webcam
            WebCamDevice device = WebCamTexture.devices[0];
            webcamTexture = new WebCamTexture(device.name);
            webcamTexture.Play();

            // Assign the webcam texture to both materials
            material.mainTexture = webcamTexture;
            material.mainTextureOffset = Vector2.zero;
            material.mainTextureScale = new Vector2(1, -1);
        }
        else
        {
            Debug.LogError("No webcam found");
            enabled = false;
        }
    }

    private void OnDestroy()
    {
        // Clear the textures when no longer active
        if (material != null) material.mainTexture = null;

        // Stop the webcam
        if (webcamTexture != null)
        {
            Debug.Log("Stopping Camera");
            webcamTexture.Stop();
        }
    }
}
