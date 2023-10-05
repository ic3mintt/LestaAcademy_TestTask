using UnityEngine;

namespace Player
{
    public class PlayerHealth: MonoBehaviour
    {
        [SerializeField] private float _health;
        
        [HideInInspector]
        public float Health;
        
        private void Start()
        {
            Health = _health;
        }
    }
}