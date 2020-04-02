using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class CannonLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject _baseBulletPrefab;

    [SerializeField] private Transform _bulletSpawner;
    /// <summary>
    /// Assigned to each created bullet as parent. Keeps the Unity object list clear.
    /// </summary>
    [SerializeField] private Transform _bulletContainer;

    [SerializeField] private CannonTrigger _cannonTrigger;
    /// <summary>
    /// Is any bullet already present in the chamber?
    /// </summary>
    private bool _isBulletPresent;
    // Start is called before the first frame update
    void Start()
    {
        if (_baseBulletPrefab == null)
        {
            throw new Exception("Base bullet prefab not found!");
        }

        if (_cannonTrigger == null)
        {
            throw new Exception("CannonTrigger mot found!");
        }

        InputReader.RegisterReload(this.Reload);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reload()
    {
        if (_isBulletPresent == false)
        {
            var newBullet = Instantiate(_baseBulletPrefab, _bulletSpawner.position, Quaternion.identity, _bulletContainer);
            _cannonTrigger.ArmProjectile(newBullet);
        }
    }
    
    public void BulletInChamber()
    {
        _isBulletPresent = true;
    }

    public void BulletLeftChamber()
    {
        _isBulletPresent = false;
    }
}
