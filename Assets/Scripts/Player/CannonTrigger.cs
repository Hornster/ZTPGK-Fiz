﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

/// <summary>
/// Responsible for shooting a loaded projectile and making sure that,
/// right after spawning, it does not fall out of the cannon.
/// </summary>
public class CannonTrigger : MonoBehaviour
{
    private const float SpringForce = 10000;
    private GameObject _loadedProjectile = null;
    private Rigidbody _loadedProjRigidBody;
    [SerializeField]
    private GameObject _cannonBarrel = null;
    [SerializeField]
    private Transform _cannonTransform;
    [SerializeField]
    private float _springStrength = 1.0f;
    /// <summary>
    /// Strength of the shot
    /// </summary>
    [SerializeField] private float _shotForce = 7.0f;

    private SpringJoint _activeSpringJoint;
    // Start is called before the first frame update
    void Start()
    {
        InputReader.RegisterShoot(Shoot);
    }
    
    /// <summary>
    /// Configures the spring that holds the armed projectile in the barrel.
    /// </summary>
    /// <param name="projectile"></param>
    public void ArmProjectile(GameObject projectile)
    {
        _loadedProjectile = projectile;
        if (_cannonBarrel.TryGetComponent<SpringJoint>(out _activeSpringJoint) == false)
        {
            _activeSpringJoint = _cannonBarrel.AddComponent<SpringJoint>();
        }
        
        _activeSpringJoint.connectedBody = _loadedProjRigidBody = _loadedProjectile.GetComponent<Rigidbody>();
        _activeSpringJoint.spring = SpringForce;
        _activeSpringJoint.damper = 0.0f;
    }
    /// <summary>
    /// Applies force to the projectile and releases the spring.
    /// </summary>
    private void Shoot()
    {
        if (_loadedProjectile == null)
        {
            return;
        }

        var forceDirVector = (_cannonTransform.rotation*_cannonBarrel.transform.localRotation)*Vector3.right;
        
        forceDirVector *= _shotForce;
        _loadedProjRigidBody.AddForce(forceDirVector);
        
        _activeSpringJoint.connectedBody = null;
        _loadedProjectile = null;
    }
}
