using System;
using GameInput;
using UnityEngine;

namespace The_FSM
{
    [Serializable]
    public abstract class State
    {
        [SerializeField] protected FSM FSM;
        [SerializeField] protected InputHandler InputHandler;
        [SerializeField] protected Rigidbody PlayerRigidbody;
        
        public virtual void Enter(){}
        public virtual void Exit(){}
        
        protected void LockInput()
        {
            InputHandler.IsMouseLocked = 
                InputHandler.IsSpaceButtonLocked = 
                    InputHandler.IsWASDLocked = true;
            PlayerRigidbody.isKinematic = true;
        }
        
        protected void UnlockInput()
        {
            InputHandler.IsMouseLocked = 
                InputHandler.IsSpaceButtonLocked = 
                    InputHandler.IsWASDLocked = false;
            PlayerRigidbody.isKinematic = false;
        }
    }
}