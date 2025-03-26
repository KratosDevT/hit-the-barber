using UnityEngine;

public class DepthCameraScript : MonoBehaviour
{
    private Camera depthCam;

    void Start()
    {
        // Ottieni il componente Camera
        depthCam = GetComponent<Camera>();

        // Crea una RenderTexture per il depth buffer
        depthCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // Imposta il Clear Flags della Depth Camera
        depthCam.clearFlags = CameraClearFlags.Depth;

        // Imposta il culling mask per visualizzare solo gli oggetti desiderati
        // depthCam.cullingMask = LayerMask.GetMask("HiddenModel"); // Se usi un layer specifico
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (depthCam != null)
        {
            // Usa la RenderTexture della Depth Camera
            Graphics.Blit(depthCam.targetTexture, dest);
        }
        else
        {
            // Se la Depth Camera non è trovata, copia direttamente la texture
            Graphics.Blit(src, dest);
        }
    }
}
