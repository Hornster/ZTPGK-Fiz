using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// Contains non-standard comparison methods.
    /// </summary>
    public class Comparator
    {
        /// <summary>
        /// Compares values of provided layers.
        /// </summary>
        /// <param name="layerMask">Layer value setup in the editor.</param>
        /// <param name="objectLayers">Layer value taken directly from the game object.</param>
        /// <returns></returns>
        public static bool CompareLayers(LayerMask layerMask, int objectLayers)
        {
            int colliderValue = 1 << objectLayers;
            int testForBullet = colliderValue & layerMask;

            return testForBullet != 0;
        }
    }
}
