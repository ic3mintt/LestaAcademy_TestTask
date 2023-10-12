using GameInput;
using TimeNotifiers;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private TimeNotifier _gameFinisher;

        private bool _isSliding;
        
        private static readonly int SLIDE = Animator.StringToHash("Slide");
        private static readonly int XMOVE = Animator.StringToHash("XRun");
        private static readonly int ZMOVE = Animator.StringToHash("ZRun");
        private static readonly int WIN = Animator.StringToHash("Win");

        private void OnEnable()
        {
            _playerMover.OnSliding += Slide;
            _playerMover.OnMoving += SetDirection;
            _gameFinisher.OnWentThrough += time => _animator.SetTrigger(WIN);
        }

        private void OnDisable()
        {
            _playerMover.OnSliding -= Slide;
            _playerMover.OnMoving -= SetDirection;
            _gameFinisher.OnWentThrough -= time => _animator.SetTrigger(WIN);
        }
        
        private void Slide() => _animator.SetTrigger(SLIDE); 

        private void SetDirection(Vector3 direction)
        {
            direction = direction.normalized;
            _animator.SetFloat(XMOVE, direction.x);
            _animator.SetFloat(ZMOVE, direction.z);
        }
    }
}