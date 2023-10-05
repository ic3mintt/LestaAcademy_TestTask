using System;
using GameInput;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _slideForce;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputHandler _inputHandler;
        
        [HideInInspector] public Vector3 AdditionalVelocity;
        
        private bool _isStopped;
        private bool _isAllowedSlide;
        private Vector3 _movementDirection;

        public event Action OnSliding; 
        public event Action<Vector3> OnMoving; 

        private void OnEnable()
        {
            _inputHandler.OnWASDChange += (direction) => _movementDirection = direction;
            _inputHandler.OnSpaceDown += () => _isAllowedSlide = true;
        }

        private void OnDisable()
        {
            _inputHandler.OnWASDChange -= (direction) => _movementDirection = direction;
            _inputHandler.OnSpaceDown -= () => _isAllowedSlide = true;
        }

        private void Update()
        {
            if (_isStopped)
            {
                OnMoving?.Invoke(Vector3.zero);
                return;
            }
            Move();
        }

        private void FixedUpdate()
        {
            if(_isStopped) return;
            
            if (_isAllowedSlide)
            {
                if (Physics.Raycast(transform.position + new Vector3(0,0.4f,0), -transform.up, 0.45f))
                {
                    Slide();
                }
                _isAllowedSlide = false;
            }
        }

        private void Move()
        {
            var delta = transform.TransformDirection(_movementDirection * (_speed * Time.deltaTime));
            _rigidbody.position += delta + AdditionalVelocity * Time.deltaTime;
            OnMoving?.Invoke(_movementDirection);
            
        }
        
        private void Slide()
        {
            _rigidbody.AddForce(transform.up * _slideForce);
            OnSliding?.Invoke();
        }

        public void StopMovement() => _isStopped = true;
        public void AllowMovement() => _isStopped = false;
    }
}