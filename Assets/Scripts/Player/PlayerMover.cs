using System;
using DefaultNamespace;
using GameInput;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float _speed;
        [SerializeField] private float _slideForce;
        
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private PlayerStopper _playerStopper;
        
        [HideInInspector] public Vector3 AdditionalVelocity;
        
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
        {if (_playerStopper.IsStopped)
            {
                OnMoving?.Invoke(Vector3.zero);
                return;
            }
            Move();
        }

        private void FixedUpdate()
        {
            if(_playerStopper.IsStopped) return;
            
            if (_isAllowedSlide)
            {
                var position = transform.position;
                if (Physics.Raycast(position, -transform.up,  position.y + 0.1f))
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
    }
}