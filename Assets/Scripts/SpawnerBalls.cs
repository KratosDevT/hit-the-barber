using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{
    private AudioSource audioSource; 
    private Camera mainCamera;
    [SerializeField] public GameObject ballPrefab;
    [SerializeField] public float force;
    [SerializeField] private AudioClip launchSound; 

    void Start()
    {
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>(); 

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject activeCamera = mainCamera.gameObject;
            GameObject clone = Instantiate<GameObject>(ballPrefab);
            clone.SetActive(true);
            clone.transform.position = activeCamera.transform.position;
            clone.transform.rotation = activeCamera.transform.rotation;


            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 launchDirection = mouseRay.direction.normalized;
            Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red, 3);

            clone.GetComponent<Rigidbody>().AddForce(launchDirection * force, ForceMode.Impulse);
            Destroy(clone, 5f);

            if (launchSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(launchSound);
            }

    }

    }
}
