using System;
using Player;
using UnityEngine;

namespace TimeNotifiers
{
    [RequireComponent(typeof(Collider))]
    public class TimeNotifier : MonoBehaviour
    {
        private bool _isWalkedThrough;
        
        public event Action<float> OnWentThrough;

        private void OnTriggerExit(Collider other)
        {
            if (_isWalkedThrough)
                return;
            
            if(!other.TryGetComponent(out PlayerHealth health))
                return;
            
            OnWentThrough?.Invoke(Time.time);
            _isWalkedThrough = true;
            enabled = false;
        }
    }
}