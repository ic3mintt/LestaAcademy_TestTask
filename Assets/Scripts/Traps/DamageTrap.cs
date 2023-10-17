using System.Collections;
using DefaultNamespace;
using Player;
using UnityEngine;

namespace Traps
{
    public class DamageTrap: Trap
    {
        [SerializeField] private float _beforeHitDelay = 1f;
        [Header("Affect settings")]
        [SerializeField] private float _damage;
        [Header("Visual settings")]
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
            _hitCoroutine ??= StartCoroutine(Hit());
        }

        private IEnumerator Hit()
        {
            _meshRenderer.material = _pressedMaterial;
            yield return new WaitForSeconds(_beforeHitDelay);
            
            _meshRenderer.material = _hitMaterial;
            
            GiveDamage();
            
            yield return new WaitForSeconds(RechargeDelay);
            _meshRenderer.material = _startMaterial;
            _hitCoroutine = null;
        }

        private void GiveDamage()
        {
            foreach (var playerHealth in Units)
            {
                playerHealth.Change(new Vector3(_damage, 0, 0));
            }
        }

        protected override IChangable GetObject(Collider other) => 
            other.gameObject.GetComponent<HealthView>();
    }
}