using UnityEngine;

namespace Player
{
    public class MovementInAnimation : MonoBehaviour
    {
        public bool IsStopped { get; private set; }
        
        public void StopMovement() => IsStopped = true;
        public void AllowMovement() => IsStopped = false;
    }
}