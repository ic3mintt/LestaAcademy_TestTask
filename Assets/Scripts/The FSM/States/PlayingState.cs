using System;
using Camera;
using Player;
using TimeNotifiers;
using UnityEngine;

namespace The_FSM
{
    [Serializable]
    public class PlayingState: State
    {
        [SerializeField] private CameraFollower _cameraFollower;
        [SerializeField] private HealthModel _playerHealth;
        [SerializeField] private TimeNotifier _gameBorder, _finishBorder;
        
        public override void Enter()
        {
            UnlockInput();
            _cameraFollower.enabled = true;
            
            _gameBorder.OnWentThrough += time => FSM.ChangeState(FSM.States.LooseState);
            _playerHealth.OnDie += () => FSM.ChangeState(FSM.States.LooseState);
            _finishBorder.OnWentThrough += time => FSM.ChangeState(FSM.States.WinState);
        }

        public override void Exit()
        {
            LockInput();
            _cameraFollower.enabled = false;
            _gameBorder.OnWentThrough -= time => FSM.ChangeState(FSM.States.LooseState);
            _playerHealth.OnDie -= () => FSM.ChangeState(FSM.States.LooseState);
            _finishBorder.OnWentThrough -= time => FSM.ChangeState(FSM.States.WinState);
        }
    }
}