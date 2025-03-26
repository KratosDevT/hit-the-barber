using UnityEngine;

public class MainCameraDepthScript : MonoBehaviour
{
    public Camera depthCamera;
    public Material depthMaterial;

    void Start()
    {
        // Imposta la Render Texture sulla Depth Camera
        depthCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (depthMaterial != null && depthCamera != null)
        {
            // Usa il depth buffer dalla Depth Camera e applicalo alla Main Camera
            Graphics.Blit(depthCamera.targetTexture, dest, depthMaterial);
        }
    }
}
