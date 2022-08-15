using UnityEngine;

public class DestroyBase : MonoBehaviour
{
    [SerializeField] private GroupEnemies _enemies;

    private bool _isPlayerEnter;

    private void Awake()
    {
        _isPlayerEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerEnter = true;
            _enemies.DestroyChild(_isPlayerEnter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerEnter = false;
            _enemies.DestroyChild(_isPlayerEnter);
        }
    }
}
