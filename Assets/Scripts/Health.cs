using System;

public class Health
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public event Action OnDied;
    public event Action<float> OnChanged;

    public Health(float maxHealth)
    {
        if (maxHealth <= 0)
            throw new System.Exception("_maxHealth cannot be equal zero or negative value");

        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        OnChanged?.Invoke(CurrentHealth);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new System.Exception("damage cannot be equal negative value");

        CurrentHealth -= damage;
        OnChanged?.Invoke(CurrentHealth);

        if (CurrentHealth < 0)
            OnDied?.Invoke();
    }

    public void Refill(float bust)
    {
        CurrentHealth = Math.Min(CurrentHealth + bust, MaxHealth);
        OnChanged?.Invoke(CurrentHealth);
    }
}
