using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{
    [SerializeField] public GameObject ballPrefab;
    [SerializeField] public float force;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject activeCamera = mainCamera.gameObject;
            GameObject clone = Instantiate<GameObject>(ballPrefab);
            clone.SetActive(true);
            clone.transform.position = activeCamera.transform.position;
            clone.transform.rotation = activeCamera.transform.rotation;

            // Calcola la direzione rispetto al centro dello schermo
            //Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
            //Vector3 mousePosition = Input.mousePosition;

            //// Calcola lo scostamento del mouse dal centro
            //Vector3 screenCenterPixels = mainCamera.ViewportToScreenPoint(screenCenter);
            //Vector3 mouseDeviation = mousePosition - screenCenterPixels;

            //// Normalizza e scala la deviazione
            //Vector3 normalizedDeviation = new Vector3(
            //    mouseDeviation.x / Screen.width,
            //    mouseDeviation.y / Screen.height,
            //    0
            //) * 1f;

            //// Crea un raggio dal centro della camera
            //Ray centerRay = mainCamera.ViewportPointToRay(screenCenter);

            //// Calcola la direzione del lancio
            //Vector3 launchDirection = centerRay.direction +
            //    mainCamera.transform.right * normalizedDeviation.x +
            //    mainCamera.transform.up * normalizedDeviation.y;

            //launchDirection = launchDirection.normalized;
            //Quaternion quaterioneRotation = mainCamera.transform.localRotation;
            //Vector3 launchDirectionFinal = Quaternion.Inverse(quaterioneRotation) * launchDirection;

            //clone.GetComponent<Rigidbody>().AddForce(clone.transform.TransformDirection(launchDirectionFinal) * force, ForceMode.Impulse);
            // Crea un raggio dal punto del mouse

            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 launchDirection = mouseRay.direction.normalized;
            Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red, 10);

            clone.GetComponent<Rigidbody>().AddForce(launchDirection * force, ForceMode.Impulse);
            Destroy(clone, 10f);
        }

    }
}
