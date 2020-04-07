using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class TargetRotatorSimple : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1.0f;
        [SerializeField]
        private Vector3 _rotationAxis = Vector3.back;

        void Update()
        {
            var time = Time.deltaTime;

            gameObject.transform.Rotate(_rotationAxis, _speed*time);
        }
    }
}
