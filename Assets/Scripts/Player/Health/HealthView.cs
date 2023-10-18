using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class HealthView: MonoBehaviour, IChangable
    {
        [SerializeField] private HealthModel _healthModel;
        private HealthController _healthController;

        private void Awake()
        {
            _healthController = new HealthController(_healthModel);
        }

        public void Change(Vector3 xDamage)
        {
            _healthController.ChangeHealthOn(xDamage.x);
        }
    }
}