using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Manages cannon movement.
    /// </summary>
    public class PlayerCannonMover : MonoBehaviour
    {
        [SerializeField] private Transform _baseTransform;
        [SerializeField] private Transform _barrelTransform;
        /// <summary>
        /// Scales the speed of movement of the player.
        /// </summary>
        [SerializeField]
        private float _movementMultiplier = 1.0f;

        // Update is called once per frame
        void Update()
        {
            float lastFrameTime = Time.deltaTime;
            //Divide the rotation between the base and barrel.
            var rotationAxis = GetAxesValues();
            var baseRotation = new Vector3(0, rotationAxis.y, 0);
            var barrelRotation = new Vector3(0, 0, rotationAxis.z);
            var scaledMovementMultiplier = _movementMultiplier * lastFrameTime;

            _baseTransform.Rotate(baseRotation, scaledMovementMultiplier);
            _barrelTransform.Rotate(barrelRotation, scaledMovementMultiplier);
        }
        /// <summary>
        /// Retrieved values of the axes, multiplied by rotation speed.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetAxesValues()
        {
            var axesValues = InputReader.ReadAxes;
            //Horizontal rotation is along the Y axis while the vertical one - Z axis.
            var rotationAxes = new Vector3(0, axesValues.x, axesValues.y);

            return rotationAxes;
        }
    }
}
