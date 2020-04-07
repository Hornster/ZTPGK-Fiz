using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ForceTest : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal") * 50 * Time.deltaTime;
        var v = Input.GetAxis("Vertical") * 50 * Time.deltaTime;

        rigidbody.AddTorque(transform.up * h);
        rigidbody.AddTorque(transform.forward * v);
    }
}
