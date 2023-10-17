using Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSetter : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private HealthModel _healthModel;

    private void OnEnable()
    {
        _healthModel.OnHealthChanged += SetSlider;
    }

    private void OnDisable()
    {
        _healthModel.OnHealthChanged -= SetSlider;
    }

    private void SetSlider(float currentValue, float maxValue)
    {
        _healthSlider.value = currentValue / maxValue;
    }
}
