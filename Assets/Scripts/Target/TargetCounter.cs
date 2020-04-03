using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Target.Interface;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Counts the amount of destroyed targets and checks how much of these are left to
/// fulfill the objective.
/// </summary>
public class TargetCounter : MonoBehaviour
{
    [SerializeField] private UnityEvent _reportTargetsDestroyed;
    [SerializeField]
    private ITarget[] targets;

    private int _allTargets;

    private int _targetsToDestroy;

    private int _destroyedTargets = 0;
    /// <summary>
    /// Defines what percent of targets player has to destroy to notify the game controller.
    /// </summary>
    [SerializeField]
    private float _targetsNeededToDestroy = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        targets = GetComponentsInChildren<ITarget>();
        _allTargets = targets.Length;
        _targetsToDestroy = Mathf.CeilToInt(_allTargets * _targetsNeededToDestroy);

        foreach (var target in targets)
        {
            target.RegisterObserveTargetDestroy(TargetDestroyed);
        }
    }
    /// <summary>
    /// Handler for event of target destruction.
    /// </summary>
    private void TargetDestroyed()
    {
        _destroyedTargets++;
        if (_destroyedTargets >= _targetsToDestroy)
        {
            _reportTargetsDestroyed?.Invoke();
        }
    }
}
