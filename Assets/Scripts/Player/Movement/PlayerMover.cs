using System;
using DefaultNamespace;
using GameInput;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour, IChangable
    {
        [Header("Values")]
        [SerializeField] private float _speed;
        [SerializeField] private float _slideForce;
        
        [Header("Components")]
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private MovementInAnimation _movementInAnimation;

        
        public event Action OnSliding; 
        public event Action<Vector3> OnMoving;

        private bool _isMovementLockedInAnimation;
        private Rigidbody _rigidbody;
        private float _distanceToFeet;
        private bool _isJumpKeyPressed;
        private Vector3 _movementDirection;
        private Vector3 _additionalVelocity;

        private void Start()
        {
            _distanceToFeet = transform.localScale.y / 2 + 0.1f;
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void OnEnable()
        {
            _inputHandler.OnWASDChange += direction => _movementDirection = direction;
            _inputHandler.OnSpaceDown += () => _isJumpKeyPressed = true;
            _movementInAnimation.OnMovementLockChange += isLocked => _isMovementLockedInAnimation = isLocked;
        }

        private void OnDisable()
        {
            _inputHandler.OnWASDChange -= direction => _movementDirection = direction;
            _inputHandler.OnSpaceDown -= () => _isJumpKeyPressed = true;
            _movementInAnimation.OnMovementLockChange -= isLocked => _isMovementLockedInAnimation = isLocked;
        }

        private void Update()
        {
            if (_isMovementLockedInAnimation)
                return;
            
            Move();
        }

        private void FixedUpdate()
        {
            if(_isMovementLockedInAnimation) return;
            
            if (_isJumpKeyPressed && _movementDirection.z >= 0)
            {
                if (Physics.Raycast(transform.position, -transform.up, _distanceToFeet))
                {
                    Slide();
                }
            }
            _isJumpKeyPressed = false;
        }

        private void Move()
        {
            var delta = transform.TransformDirection(_movementDirection * (_speed * Time.deltaTime));
            _rigidbody.position += delta + _additionalVelocity * Time.deltaTime;
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