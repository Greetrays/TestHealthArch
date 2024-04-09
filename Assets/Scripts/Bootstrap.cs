using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private HealthView _healthView;

    private void Start()
    {
        Player player = Instantiate(_playerPrefab, new Vector2(0, 0), Quaternion.identity);
        player.Initialize();

        _healthView.Initialize(player);
    }
}
