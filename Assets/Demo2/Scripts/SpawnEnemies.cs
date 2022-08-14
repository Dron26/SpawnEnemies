using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _spawnedEnemy;
    [SerializeField] private PlayerBase _playerBase;
    [SerializeField] private DestroyBase _destroyBase;

    private ParticleSystem _particleSpawn;
    private bool _isSpawnStart;
    private bool _isPlayerAlive;

    private void Awake()
    {
        _particleSpawn =GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _isSpawnStart = false;
        StartCoroutine(Spawn());       
    }

    private void Update()
    {
        _isPlayerAlive = _player.IsAlive;
        _isSpawnStart = _playerBase.isPlayerEnter(); 
    }

    private IEnumerator Spawn()
    {       
        int timeForWaite = 2;
        _isPlayerAlive = _player.IsAlive;

        while (_isPlayerAlive == true)
        {
            if (_isSpawnStart == true)
            {

                Enemy enemy=Instantiate(_spawnedEnemy, transform.position, Quaternion.identity);
                enemy.SetPlayer(_player);
                enemy.SetDestroyBase(_destroyBase);
                _particleSpawn.Play();
                yield return new WaitForSeconds(timeForWaite);
            }
            else
            {
                yield return null;
            }
        }        
    }
}
