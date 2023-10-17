using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Health", fileName = "Health")]
    public class HealthModel : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [HideInInspector] public float Health;
        public event Action OnDie;
        public event Action<float, float> OnHealthChanged;

        public void OnEnable() => Health = _maxHealth;
        public void OnDieInvoke() => OnDie?.Invoke();
        public void HealthChangedInvoke() => OnHealthChanged?.Invoke(Health, _maxHealth);
    }
}