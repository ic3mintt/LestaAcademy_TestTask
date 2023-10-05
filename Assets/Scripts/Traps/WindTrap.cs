using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Traps
{
    
    
    public class WindTrap: Trap
    {
        [SerializeField] private float _windForce;
        [SerializeField] private float _delay;

        private bool _isAllowedBlowing;
        private Coroutine _windCoroutine;
        private List<Vector3> _allowedDirections;

        protected override void Start()
        {
            base.Start();
            _allowedDirections = new List<Vector3>()
            {
                Vector3.back,
                Vector3.forward,
                Vector3.right,
                Vector3.left
            };
        }

        protected override void Activate()
        {
            if (_windCoroutine == null) _windCoroutine = StartCoroutine(Blow());
        }

        private IEnumerator Blow()
        {
            GiveVelocityToUnits(_allowedDirections[Random.Range(0, _allowedDirections.Count)] * _windForce);
            yield return new WaitForSeconds(_delay);
            _windCoroutine = null;
        }

        private void GiveVelocityToUnits(Vector3 velocity)
        {
            foreach (var unit in Units)
            {
                if (unit.TryGetComponent(out PlayerMover playerMover))
                {
                    playerMover.AdditionalVelocity = velocity;
                }
            }
        }

        protected override void RemoveUnit(Collider other)
        {
            try
            {
                if (GetObject(other).TryGetComponent(out PlayerMover playerMover))
                {
                    playerMover.AdditionalVelocity = Vector3.zero;
                }
            }
            catch (Exception e) { }
        }
    }
}