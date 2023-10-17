using System;
using TimeNotifiers;
using TMPro;
using UnityEngine;

namespace The_FSM
{
    [Serializable]
    public class WinState: EndGameState
    {
        [SerializeField] private TextMeshProUGUI _time;
        [SerializeField] private TimeNotifier _startLine, _finishLine;

        public override void Enter()
        {
            base.Enter();
            if (_time != null)
            {
                SetCanvasTime(_finishLine.CatchedTime - _startLine.CatchedTime);
            }
        }

        private void SetCanvasTime(float resultTime)
        {
            var timeSpan = TimeSpan.FromSeconds(Mathf.Floor(resultTime));

            if (timeSpan.Hours != 0)
            {
                _time.text = timeSpan.ToString();
                return;
            }

            if (timeSpan.Minutes != 0)
            {
                _time.text = $"{timeSpan.Minutes}:{timeSpan.Seconds}";
                return;
            }

            _time.text = Math.Round(resultTime, 2).ToString();
        }
    }
}