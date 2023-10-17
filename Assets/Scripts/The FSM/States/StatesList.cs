using System;

namespace The_FSM
{
    [Serializable]
    public class StatesList
    {
        public ShowLandscapeState ShowLandscapeState;
        public PlayingState PlayingState;
        public EndGameState LooseState;
        public WinState WinState;
    }
}