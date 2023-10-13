using Player;
using TimeNotifiers;
using UnityEngine;

namespace DefaultNamespace
{
    public class LooseGameController : MonoBehaviour
    {
        [Header("UI components")]
        [SerializeField] private Canvas _looseCanvas;
        [Header("Game components")]
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private TimeNotifier _playerFallBorder;
        
        private void OnEnable()
        {
            _playerHealth.OnDie += Loose;
            _playerFallBorder.OnWentThrough += time => Loose();
        }

        private void OnDisable()
        {
            _playerHealth.OnDie -= Loose;
            _playerFallBorder.OnWentThrough -= time => Loose();
        }

        private void Loose()
        {
            GameStopper.PauseGame();
            _looseCanvas.gameObject.SetActive(true);
        }
    }
}