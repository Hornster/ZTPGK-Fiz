using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArmProjectile(GameObject projectile)
    {
        _loadedProjectile = projectile;
        _activeSpringJoint = _cannonBarrel.AddComponent<SpringJoint>();
        _activeSpringJoint.connectedBody = _loadedProjRigidBody = _loadedProjectile.GetComponent<Rigidbody>();
    }

    private void Shoot()
    {
        if (_loadedProjectile == null)
        {
            return;
        }

        var forceDirVector = (_cannonTransform.rotation*_cannonBarrel.transform.rotation)*Vector3.right;
        //forceDirVector = _cannonBarrel.transform.rotation * forceDirVector;
        forceDirVector *= _shotForce;
        _loadedProjRigidBody.AddForce(forceDirVector);

        _activeSpringJoint.connectedBody = null;
        _loadedProjectile = null;
    }
}
