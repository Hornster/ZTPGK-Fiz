using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class GuiController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _victoryText;
        [SerializeField]
        private TMP_Text _pressEscText;

        public void EnableVictoryText()
        {
            _victoryText.enabled = true;
            _pressEscText.enabled = true;
        }
    }
}
