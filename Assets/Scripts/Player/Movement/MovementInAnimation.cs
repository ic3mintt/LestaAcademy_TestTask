using System;
using UnityEngine;

namespace Player
{
    //it is not a scriptable object because 
    //Functions are invoked directly from the slide animation
    public class MovementInAnimation : MonoBehaviour
    {
        private bool _isStopped;
        public event Action<bool> OnMovementLockChange;

        public void StopMovement()
        {
            _isStopped = true;
            OnMovementLockChange?.Invoke(_isStopped);
        }

        public void AllowMovement()
        {
            _isStopped = false;   
            OnMovementLockChange?.Invoke(_isStopped);
        }
    }
}