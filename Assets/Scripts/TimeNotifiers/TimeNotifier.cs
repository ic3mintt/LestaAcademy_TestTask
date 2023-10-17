using System;
using Player;
using UnityEngine;

namespace TimeNotifiers
{
    [RequireComponent(typeof(Collider))]
    public class TimeNotifier : MonoBehaviour
    {
        public float CatchedTime;
        private bool _isWalkedThrough;
        
        public event Action<float> OnWentThrough;

        private void OnTriggerExit(Collider other)
        {
            if (_isWalkedThrough)
                return;
            
            if(!other.TryGetComponent(out HealthView health))
                return;

            CatchedTime = Time.time;
            OnWentThrough?.Invoke(CatchedTime);
            _isWalkedThrough = true;
            enabled = false;
        }
    }
}