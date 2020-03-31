using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainHeadBreaker : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _chainHead;
    private Collider _collider;
    /// <summary>
    /// What objects can disable the chain's head hanging midair?
    /// </summary>
    [SerializeField]
    private LayerMask _testAgainstLayers;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        if (_chainHead == null)
        {
            throw new Exception("Rigidbody not found!");
        }
        if (_collider == null)
        {
            throw new Exception("Collider not found! It is required for collision detection!");
        }
    }

    void OnTriggerEnter(Collider _colliderData)
    {
        int colliderValue = 1 << _colliderData.gameObject.layer;
        int testForBullet = colliderValue & _testAgainstLayers;
        if (testForBullet != 0)
        {
            _chainHead.isKinematic = false;
        }
    }
}
