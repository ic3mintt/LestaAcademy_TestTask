using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Traps
{
    public class WindTrap: Trap
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _windForce;

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
            _windCoroutine ??= StartCoroutine(Blow());
        }

        private IEnumerator Blow()
        {
            GiveVelocityToUnits(_allowedDirections[Random.Range(0, _allowedDirections.Count)] * _windForce);
            yield return new WaitForSeconds(_delay);
            _windCoroutine = null;
        }

        private void GiveVelocityToUnits(Vector3 velocity)
        {
            foreach (var playerVelocity in Units)
            {
                playerVelocity.Change(Vector3.zero);
                playerVelocity.Change(velocity);
            }
        }

        protected override void RemoveUnit(Collider other)
        {
            try
            {
                var playerVelocity = GetObject(other);
                playerVelocity.Change(Vector3.zero);
            }catch (Exception e) { }
        }

        protected override IChangable GetObject(Collider other) =>
            other.gameObject.GetComponent<PlayerMover>();
    }
}