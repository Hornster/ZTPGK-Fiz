using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Target.Interface;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Target
{
    public class TargetComponent : MonoBehaviour, ITargetComponent
    {
        private UnityAction _reportTakingHit;
        /// <summary>
        /// What objects will destroy the component?
        /// </summary>
        [SerializeField]
        private LayerMask _reactsToLayers;
        [SerializeField]
        private Color _destroyedColor;

        public void RegisterTakingHitHandler(UnityAction handler)
        {
            _reportTakingHit += handler;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (Comparator.CompareLayers(_reactsToLayers, collision.gameObject.layer))
            {
                _reportTakingHit?.Invoke();
            }
        }

        public void ChangeColor()
        {
            var material = GetComponent<MeshRenderer>().material;
            material.color = _destroyedColor;
        }
    }
}
