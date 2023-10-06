using System;
using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _yOffset;
        [SerializeField] private Vector3 _cameraOffset;
        [SerializeField] private Transform _target;

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            transform.position = _target.TransformPoint(_cameraOffset);
        }

        private void Rotate()
        {
            var direction = _target.position - transform.position;
            direction.y = _yOffset;
            transform.rotation = Quaternion.LookRotation(direction.normalized);
        }
    }
}