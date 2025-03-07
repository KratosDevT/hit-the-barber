using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{
    [SerializeField]
    public GameObject modelBall;
    [SerializeField]
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject activeCamera=Camera.main.gameObject;
            GameObject clone = Instantiate<GameObject>(modelBall);
            clone.SetActive(true);
            clone.transform.position = activeCamera.transform.position;
            clone.transform.rotation = activeCamera.transform.rotation;
            Vector3 deviation = new Vector3(Random.Range(-0.30f, 0.5f), Random.Range(-0.5f, 0.5f),1);
            //clone.GetComponent<Rigidbody>().AddForce(clone.transform.TransformDirection(Vector3.forward)* force, ForceMode.Impulse);
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.TransformDirection(deviation) * force, ForceMode.Impulse);
        }

    }
}
