using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealthChangeble
{
    [SerializeField, Range(1, 100)] private float _maxHealth;

    private Health _health;

    public float MaxHealth { get => _health.MaxHealth; }
    public float CurrentHealth { get => _health.CurrentHealth; }

    public event Action<float> OnChanged;

    public void Initialize()
    {
        _health = new Health(_maxHealth);
        _health.OnDied += Die;
        _health.OnChanged += ChangeHealth;
    }

    public void OnDisable()
    {
        _health.OnChanged -= ChangeHealth;
    }

    private void ChangeHealth(float currentHealth)
    {
        OnChanged?.Invoke(currentHealth);
        Debug.Log(2222);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        _health.TakeDamage(1);
    }
}
