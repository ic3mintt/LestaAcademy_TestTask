using System.Collections;
using Player;
using UnityEngine;

namespace Traps
{
    public class HealthTakerTrap: Trap
    {
        [SerializeField] private float _damage;
        [Header("Time")]
        [SerializeField] private float _rechargeDelay = 5f;
        [SerializeField] private float _beforeHitDelay = 1f;
        [Header("Visual")]
        [SerializeField] private Material _startMaterial;
        [SerializeField] private Material _pressedMaterial;
        [SerializeField] private Material _hitMaterial;
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private Coroutine _hitCoroutine;

        protected override void Start()
        {
            base.Start();
            _meshRenderer.material = _startMaterial;
        }

        protected override void Activate()
        {
            if (_hitCoroutine == null)
            {
                _hitCoroutine = StartCoroutine(Hit());
            }
        }

        private IEnumerator Hit()
        {
            _meshRenderer.material = _pressedMaterial;
            yield return new WaitForSeconds(_beforeHitDelay);
            
            _meshRenderer.material = _hitMaterial;
            
            GiveDamage();
            
            yield return new WaitForSeconds(_rechargeDelay);
            _meshRenderer.material = _startMaterial;
            
            _hitCoroutine = null;
        }

        private void GiveDamage()
        {
            foreach (var unit in Units)
            {
                unit.GetComponent<PlayerHealth>().Health -= _damage;
            }
        }

        protected override GameObject GetObject(Collider other) => other.gameObject.GetComponentInParent<PlayerHealth>().gameObject;
    }
}