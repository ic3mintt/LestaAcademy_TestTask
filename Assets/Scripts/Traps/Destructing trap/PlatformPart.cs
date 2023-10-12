using UnityEngine;

namespace Traps
{
    public class PlatformPart
    {
        private readonly Vector3 _startPosition;
        private readonly Quaternion _startRotation;
        private readonly Rigidbody _rigidbody;

        public PlatformPart(Rigidbody rigidbody)
        {
            _startPosition = rigidbody.position;
            _startRotation = rigidbody.rotation;
            _rigidbody = rigidbody;
        }

        public void Fall(Vector3 angularVelocity)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.angularVelocity = angularVelocity;
        }

        public void Return()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.transform.position = _startPosition;
            _rigidbody.transform.rotation = _startRotation;
        }
    }
}