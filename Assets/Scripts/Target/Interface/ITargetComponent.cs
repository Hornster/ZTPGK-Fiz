using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Target.Interface
{
    public interface ITargetComponent
    {
        /// <summary>
        /// Makes the component to change its color. The color is known to the component.
        /// </summary>
        void ChangeColor();

        void RegisterTakingHitHandler(UnityAction handler);
    }
}
