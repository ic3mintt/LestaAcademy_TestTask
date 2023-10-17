using System;
using DefaultNamespace;
using TimeNotifiers;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace The_FSM
{
    [Serializable]
    public class EndGameState: State
    {
        [SerializeField] private Canvas _canvas; 
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameRestarter _gameRestarter;
        
        public override void Enter()
        {
            LockInput();
            _canvas.gameObject.SetActive(true);
            
            _restartButton.onClick.AddListener(()=>
            {
                _gameRestarter.ReloadScene();
            });
        }

        public override void Exit(){}
    }
}