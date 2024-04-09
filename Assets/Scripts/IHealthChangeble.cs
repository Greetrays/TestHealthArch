using System;

public interface IHealthChangeble
{
    public float MaxHealth { get; }
    public float CurrentHealth { get; }

    public event Action<float> OnChanged;
}