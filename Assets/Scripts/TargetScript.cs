using TMPro;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float zMin = -2.5f;
    public float zMax = 9f;
    private bool movingForward = true;
    private int counter;
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private TextMeshProUGUI counterText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
        if (hitSound != null && audioSource != null) // && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hitSound);
        }
        ++counter;
        counterText.SetText(counter.ToString());
        //Destroy(gameObject);
    }
}
