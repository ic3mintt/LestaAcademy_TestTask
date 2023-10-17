namespace Player
{
    public class HealthController
    {
        private readonly HealthModel _model;

        public HealthController(HealthModel model) => _model = model;

        public void ChangeHealthOn(float damage)
        {
            _model.Health -= damage;
            _model.HealthChangedInvoke();
            
            if (_model.Health <= 0)
                _model.OnDieInvoke();
        }
    }
}