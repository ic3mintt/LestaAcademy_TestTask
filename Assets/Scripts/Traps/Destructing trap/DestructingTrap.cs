using DefaultNamespace;
using Player;
using UnityEngine;

namespace Traps
{
    public class DestructingTrap : Trap
    {
        [SerializeField] private GameObject _wholePlatform;
        [SerializeField] private DestructedPlatform _destructingPlatform;

        private bool _isActivated;
        
        private void Awake()
        {
            _destructingPlatform.Initialize(RechargeDelay);
        }

        protected override void Start()
        {
            base.Start();
            _destructingPlatform.gameObject.SetActive(false);
        }

        protected override void Activate()
        {
            if (_isActivated)
                return;
            
            _wholePlatform.SetActive(false);
            _destructingPlatform.gameObject.SetActive(true);
            _destructingPlatform.StartFall();
            _isActivated = true;
        }

        protected void Deactivate()
        {
            _isActivated = false;
            _destructingPlatform.EndFall();
            _wholePlatform.SetActive(true);
            _destructingPlatform.gameObject.SetActive(false);
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            Deactivate();
        }

        protected override void OnTriggerStay(Collider other){}

        protected override IChangable GetObject(Collider other) => other.gameObject.GetComponent<HealthView>();
    }
}