using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    [SerializeField]
    private float force = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Player entered the trigger.");
        }
    }

    void OnTriggerStay(Collider collider)
    {
        collider.GetComponent<Rigidbody>().AddForce(Vector3.up* force);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player left the trigger.");
        }
    }
}
