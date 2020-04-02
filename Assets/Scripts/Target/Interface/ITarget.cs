using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Target.Interface
{
    public interface ITarget
    {
        /// <summary>
        /// Registers provided method to be called when the target becomes destroyed.
        /// </summary>
        /// <param name="handler">Will be called upon target destruction.</param>
        void RegisterObserveTargetDestroy(UnityAction handler);
    }
}
