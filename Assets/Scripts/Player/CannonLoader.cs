using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

/// <summary>
/// Takes care of reloading the cannon.
/// </summary>
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
    /// <summary>
    /// If no bullet is currently present, creates new bullet instance in the cannon chamber.
    /// </summary>
    void Reload()
    {
        if (_isBulletPresent == false)
        {
            var newBullet = Instantiate(_baseBulletPrefab, _bulletSpawner.position, Quaternion.identity, _bulletContainer);
            _cannonTrigger.ArmProjectile(newBullet);
        }
    }
    /// <summary>
    /// Event handler. Used by outside classes to tell the loader that a bullet is already present
    /// inside the spawn area.
    /// </summary>
    public void BulletInChamber()
    {
        _isBulletPresent = true;
    }
    /// <summary>
    /// Event handler. Used by outside classes to tell the loader that there are no bullets present
    /// inside the spawn area.
    /// </summary>
    public void BulletLeftChamber()
    {
        _isBulletPresent = false;
    }
}
