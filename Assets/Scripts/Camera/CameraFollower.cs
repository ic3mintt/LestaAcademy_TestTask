using System;
using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _cameraOffset;
        [SerializeField] private Vector3 _targetOffset;

        private void Update()
        {
            Move();
            Rotate();
        }
        
        private void Move() => transform.position = _target.TransformPoint(_cameraOffset);

        private void Rotate()
        {
            var direction = _target.position - transform.position;
            direction += _targetOffset;
            transform.rotation = Quaternion.LookRotation(direction.normalized);
        }
    }
}