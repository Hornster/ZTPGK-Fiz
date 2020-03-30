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
        [SerializeField]
        private KeyCode ReloadKey = KeyCode.R;

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

        private void ChkKeys()
        {
            if (Input.GetKeyDown(ReloadKey))
            {
                _reloadHandler?.Invoke();
            }
        }
    }
}
