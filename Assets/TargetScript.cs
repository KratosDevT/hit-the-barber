using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed = 5.0f; // Velocità del movimento
    public float zMin = -2.5f;   // Limite minimo su Z
    public float zMax = 9f;    // Limite massimo su Z
    private bool movingForward = true;
    [SerializeField] private AudioClip hitSound; 
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Prende il componente AudioSource
    }

    void Update()
    {
        // Movimento avanti e indietro tra zMin e zMax
        float step = speed * Time.deltaTime;
        if (movingForward)
        {
            transform.position += new Vector3(0, 0, step);
            if (transform.position.z >= zMax)
                movingForward = false;
        }
        else
        {
            transform.position -= new Vector3(0, 0, step);
            if (transform.position.z <= zMin)
                movingForward = true;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (hitSound != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hitSound);
        }

        //Destroy(gameObject);
    }
}
