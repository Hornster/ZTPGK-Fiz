using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Controls all GUI elements.
    /// </summary>
    public class GuiController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _victoryText;
        [SerializeField]
        private TMP_Text _pressEscText;
        /// <summary>
        /// Event handler - called to show the victory text when victory is achieved by the player.
        /// </summary>
        public void EnableVictoryText()
        {
            _victoryText.enabled = true;
            _pressEscText.enabled = true;
        }
    }
}
