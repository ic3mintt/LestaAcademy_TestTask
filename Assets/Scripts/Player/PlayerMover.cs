using System;
using DefaultNamespace;
using GameInput;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour, IChangable
    {
        [Header("Values")]
        [SerializeField] private float _speed;
        [SerializeField] private float _slideForce;
        
        [Header("Components")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private PlayerStopper _playerStopper;
        
        private bool _isJumpKeyPressed;
        private Vector3 _movementDirection;
        private Vector3 _additionalVelocity;

        public event Action OnSliding; 
        public event Action<Vector3> OnMoving;

        private void OnEnable()
        {
            _inputHandler.OnWASDChange += (direction) => _movementDirection = direction;
            _inputHandler.OnSpaceDown += () => _isJumpKeyPressed = true;
        }

        private void OnDisable()
        {
            _inputHandler.OnWASDChange -= (direction) => _movementDirection = direction;
            _inputHandler.OnSpaceDown -= () => _isJumpKeyPressed = true;
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
            
            if (_isJumpKeyPressed && Mathf.Approximately(_movementDirection.x, 0f) 
                && _movementDirection.z > 0)
            {
                var position = transform.position;
                if (Physics.Raycast(position, -transform.up,  position.y + 0.1f))
                {
                    Slide();
                }
                _isJumpKeyPressed = false;
            }
        }

        private void Move()
        {
            var delta = transform.TransformDirection(_movementDirection * (_speed * Time.deltaTime));
            _rigidbody.position += delta;
            _rigidbody.position += _additionalVelocity * Time.deltaTime;
            OnMoving?.Invoke(_movementDirection);
            
        }
        
        private void Slide()
        {
            _rigidbody.AddForce(transform.up * _slideForce);
            OnSliding?.Invoke();
        }

        public void Change(Vector3 additiveVelocity)
        {
            _additionalVelocity = additiveVelocity;
            if(additiveVelocity == Vector3.zero)
                _rigidbody.velocity = Vector3.zero;
        } 
    }
}