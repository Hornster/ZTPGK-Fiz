using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Reads the input from the player.
    /// </summary>
    public class InputReader : MonoBehaviour
    {
        /// <summary>
        /// Stores handlers for reload button pressed event.
        /// </summary>
        private static UnityAction _reloadHandler = null;
        /// <summary>
        /// Stores handlers for shoot button pressed event.
        /// </summary>
        private static UnityAction _shootHandler = null;
        /// <summary>
        /// Stores handlers for exit button pressed event.
        /// </summary>
        private static UnityAction _exitGameHandler = null;
        [SerializeField]
        private KeyCode ReloadKey = KeyCode.R;
        [SerializeField]
        private KeyCode ShootKey = KeyCode.Space;
        [SerializeField]
        private KeyCode ExitKey = KeyCode.Escape;
        /// <summary>
        /// Stores the raw values of read axes - horizontal and vertical.
        /// </summary>
        public static Vector2 ReadAxes { get; private set; }

        /// <summary>
        /// Reads the input axes and calls for other controls checks.
        /// </summary>
        private void Update()
        {
            ReadAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            ChkKeys();
        }
        /// <summary>
        /// Registers reload event handler.
        /// </summary>
        /// <param name="handler"></param>
        public static void RegisterReload(UnityAction handler)
        {
            _reloadHandler += handler;
        }
        /// <summary>
        /// Registers shoot event handler.
        /// </summary>
        public static void RegisterShoot(UnityAction handler)
        {
            _shootHandler += handler;
        }
        /// <summary>
        /// Registers exit event handler.
        /// </summary>
        public static void RegisterExit(UnityAction handler)
        {
            _exitGameHandler += handler;
        }
        /// <summary>
        /// Checks whether were any special keys pressed.
        /// </summary>
        private void ChkKeys()
        {
            if (Input.GetKeyDown(ReloadKey))
            {
                _reloadHandler?.Invoke();
            }
            if (Input.GetKeyDown(ShootKey))
            {
                _shootHandler?.Invoke();
            }

            if (Input.GetKeyDown(ExitKey))
            {
                _exitGameHandler?.Invoke();
            }
        }
    }
}
