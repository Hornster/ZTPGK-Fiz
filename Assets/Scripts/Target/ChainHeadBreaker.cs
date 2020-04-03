using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using UnityEngine;

/// <summary>
/// Used to break the heads of mid-air hanging chains.cja dla głowy 
/// </summary>
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
        if (Comparator.CompareLayers(_testAgainstLayers, _colliderData.gameObject.layer))
        {
            _chainHead.isKinematic = false;
        }
    }
}
