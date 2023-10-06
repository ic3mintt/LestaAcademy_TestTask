using Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSetter : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += SetSlider;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= SetSlider;
    }

    private void SetSlider(float currentValue, float maxValue)
    {
        _healthSlider.value = currentValue / maxValue;
    }
}
