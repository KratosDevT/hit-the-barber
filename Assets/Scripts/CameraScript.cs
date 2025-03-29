using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RenderTexture viewTexture;

    [SerializeField] Camera secondCamera;


    void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            
            secondCamera.targetTexture = viewTexture;
            
        }
    }
}
