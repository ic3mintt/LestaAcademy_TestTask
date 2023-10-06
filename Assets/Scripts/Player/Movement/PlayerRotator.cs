using System;
using GameInput;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private InputHandler _inputHandler;

        private float _mouseXDirection;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _inputHandler.OnMouseXChange += SetMouseX;
        }
        
        private void OnDisable()
        {
            _inputHandler.OnMouseXChange -= SetMouseX;
        }

        private void FixedUpdate()
        {
            var yRotation = transform.rotation.eulerAngles.y + _mouseXDirection * _speed * Time.fixedTime;
            _rigidbody.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        private void SetMouseX(float value)
        {
            _mouseXDirection = Mathf.Clamp(value, -1, 1); 
        }
    }
}