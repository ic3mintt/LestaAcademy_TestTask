using System;
using TimeNotifiers;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class WinGameController : MonoBehaviour
    {
        [Header("UI components")]
        [SerializeField] private Canvas _winCanvas;
        [SerializeField] private TextMeshProUGUI _time;
        [Header("Game components")]
        [SerializeField] private TimeNotifier _gameStarter, _gameFinisher;
        
        private float _startTime, _finishTime;

        private void OnEnable()
        {
            _gameStarter.OnWentThrough += time => _startTime = time;
            _gameFinisher.OnWentThrough += time => { _finishTime = time; Win(_finishTime - _startTime); };
        }

        private void OnDisable()
        {
            _gameStarter.OnWentThrough -= time => _startTime = time;
            _gameFinisher.OnWentThrough -= time => { _finishTime = time; Win(_finishTime - _startTime); };
        }

        private void Win(float resultTime)
        {
            _winCanvas.gameObject.SetActive(true);
            SetCanvasTime(resultTime);
            GameStopper.PauseGame();
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