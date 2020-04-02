using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    public class InputReader : MonoBehaviour
    {
        private static UnityAction _reloadHandler = null;
        private static UnityAction _shootHandler = null;
        private static UnityAction _exitGameHandler = null;
        [SerializeField]
        private KeyCode ReloadKey = KeyCode.R;
        [SerializeField]
        private KeyCode ShootKey = KeyCode.Space;
        [SerializeField]
        private KeyCode ExitKey = KeyCode.Escape;

        public static Vector2 ReadAxes { get; private set; }

        
        private void Update()
        {
            ReadAxes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            ChkKeys();
        }

        public static void RegisterReload(UnityAction handler)
        {
            _reloadHandler += handler;
        }

        public static void RegisterShoot(UnityAction handler)
        {
            _shootHandler += handler;
        }

        public static void RegisterExit(UnityAction handler)
        {
            _exitGameHandler += handler;
        }

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
