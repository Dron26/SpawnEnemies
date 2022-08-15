using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private  SpawnerEnemies _spawnerEnemies;
    private bool _isPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerEnter = true;
           _spawnerEnemies.SetStart(_isPlayerEnter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerEnter = false;
            _spawnerEnemies.SetStart(_isPlayerEnter);
        }
    }
}
