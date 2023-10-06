using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStopper : MonoBehaviour
    {
        public bool IsStopped { get; private set; }
        
        public void StopMovement() => IsStopped = true;
        public void AllowMovement() => IsStopped = false;
    }
}