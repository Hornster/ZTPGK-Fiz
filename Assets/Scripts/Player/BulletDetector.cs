using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.Events;

public class BulletDetector : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private UnityEvent _bulletDetected;
    /// <summary>
    /// Called when the bullet exits the collider.
    /// </summary>
    [SerializeField] private UnityEvent _bulletGone;
    /// <summary>
    /// Defines what types of objects will be checked.
    /// </summary>
    [SerializeField] private LayerMask _bulletLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (Comparator.CompareLayers(_bulletLayers, collider.gameObject.layer))
        {
            _bulletDetected?.Invoke();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (Comparator.CompareLayers(_bulletLayers, collider.gameObject.layer))
        {
            _bulletGone?.Invoke();
        }
    }
}
