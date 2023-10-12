using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class DestructedPlatform : MonoBehaviour
    {
        
        [SerializeField] private Vector3 _partAngularVelocity;
        [SerializeField] private List<Rigidbody> _partsRigidbodies;

        private float _fallDelay;
        private List<PlatformPart> _parts;
        private Coroutine _fallingCoroutine;

        private void Awake()
        {
            _parts = new List<PlatformPart>(_partsRigidbodies.Count);
            
            foreach (var rigidbody in _partsRigidbodies)
            {
                _parts.Add(new PlatformPart(rigidbody));
            }
        }

        public void Initialize(float fallDelay) => _fallDelay = fallDelay;
        
        public void StartFall()
        {
            _fallingCoroutine = StartCoroutine(Fall());
        }

        private IEnumerator Fall()
        {
            for (int i = 0; i < _parts.Count; i++)
            {
                _parts[i].Fall(_partAngularVelocity);
                yield return new WaitForSeconds(_fallDelay);
            }

            _fallingCoroutine = null;
        }

        public void EndFall()
        {
            if (_fallingCoroutine != null)
            {
                StopCoroutine(_fallingCoroutine);
                _fallingCoroutine = null;
            }
            
            foreach (var part in _parts)
            {
                part.Return();
            }
        }
    }
}