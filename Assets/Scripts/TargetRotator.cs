using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class TargetRotator : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _rotationForce = 1.0f;
    [SerializeField]
    private Vector3 _forceVectorNormalized = new Vector3(0, 1, 0);
    
    [SerializeField]
    private float _maxVelocity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _forceVectorNormalized = _forceVectorNormalized.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody.angularVelocity.magnitude < _maxVelocity)
        {
            var position = CalcPosition();
            _rigidbody.AddForceAtPosition(_forceVectorNormalized*_rotationForce, position);
        }
    }

    private Vector3 CalcPosition()
    {
        var collider = GetComponent<Collider>();
        return transform.position - collider.bounds.extents;
    }
}
