using System;
using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    
    private IHealthChangeble _health;

    public void Initialize(IHealthChangeble health)
    {
        _health = health;
        _health.OnChanged += Change;
        Debug.Log(111);
    }

    private void OnDisable()
    {
        _health.OnChanged -= Change;
    }

    private void Change(float currentHealth)
    {
        Debug.Log(11111);
        _healthText.text = currentHealth.ToString();
    }
}
