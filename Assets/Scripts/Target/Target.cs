using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Target.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Target
{
    public class Target : MonoBehaviour, ITarget
    {
        private UnityAction _targetDestructionObservers;

        private bool _isDestroyed = false;

        private ITargetComponent[] _targetComponents;

        void Start()
        {
            _targetComponents = GetComponentsInChildren<ITargetComponent>();
            foreach (var component in _targetComponents)
            {
                component.RegisterTakingHitHandler(TargetDestroyed);
            }
        }

        public void RegisterObserveTargetDestroy(UnityAction handler)
        {
            _targetDestructionObservers += handler;
        }

        private void TargetDestroyed()
        {
            if (_isDestroyed == false)
            {
                _targetDestructionObservers?.Invoke();
                foreach (var targetComponent in _targetComponents)
                {
                    targetComponent.ChangeColor();
                }
                _isDestroyed = true;
            }
        }
    }
}
