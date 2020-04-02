using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class Comparator
    {
        public static bool CompareLayers(LayerMask layerMask, int objectLayers)
        {
            int colliderValue = 1 << objectLayers;
            int testForBullet = colliderValue & layerMask;

            return testForBullet != 0;
        }
    }
}
