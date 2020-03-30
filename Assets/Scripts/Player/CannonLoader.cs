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
    // Start is called before the first frame update
    void Start()
    {
        if (_baseBulletPrefab == null)
        {
            throw new Exception("Base bullet prefab not found!");
        }

        InputReader.RegisterReload(this.Reload);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reload()
    {
        Instantiate(_baseBulletPrefab, _bulletSpawner);
    }
}
