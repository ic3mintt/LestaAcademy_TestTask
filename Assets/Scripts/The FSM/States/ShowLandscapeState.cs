using System;
using Camera;
using Player;
using UnityEngine;

namespace The_FSM
{
    [Serializable]
    public class ShowLandscapeState: State
    {
        [SerializeField] private Canvas _playerHealth;
        [Header("Camera settings")]
        [SerializeField] private Animator _cameraAnimator;
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private MovementInAnimation _cameraMovementInAnimation;
        
        public override void Enter()
        {
            LockInput();
            ShowLandscape();
            _playerHealth.gameObject.SetActive(false);
            
            _cameraMovementInAnimation.OnMovementLockChange += isLocked => {
                if(isLocked)
                    FSM.ChangeState(FSM.States.PlayingState);
            };
        }

        public override void Exit()
        {
            StopShowLandscape();
            _playerHealth.gameObject.SetActive(true);
            
            
            _cameraMovementInAnimation.OnMovementLockChange -= isLocked => {
                if(isLocked)
                    FSM.ChangeState(FSM.States.PlayingState);
            };
        }

        private void ShowLandscape()
        {
            _cameraAnimator.enabled = true;
            _cameraFollower.enabled = false;
        }

        private void StopShowLandscape()
        {
            _cameraAnimator.enabled = false;
            _cameraFollower.enabled = true;
        }
    }
}