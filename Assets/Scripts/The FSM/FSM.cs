using UnityEngine;

namespace The_FSM
{
    public class FSM: MonoBehaviour
    {
        public StatesList States;
        
        private State _currentState;
        
        private void Start()
        {
            ChangeState(States.ShowLandscapeState);
        }

        public void ChangeState(State state)
        {
            if(state == null)
                return;
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}