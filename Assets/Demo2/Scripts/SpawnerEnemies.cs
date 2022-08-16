using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _spawnedEnemy;
    [SerializeField] private DestroyBase _destroyBase;
    [SerializeField] private Transform _groupSpawnedEnemies;
    [SerializeField] private ParticleSystem _particleEnemyRespawnBase;

    private bool _isSpawnStart;
    private WaitForSeconds _shortWait;
    private bool _corountineWork;

    public void SpawnStart(bool isStart)
    {
        _isSpawnStart = isStart;
        if (_isSpawnStart)
        {
            StartCoroutine(Spawn(_shortWait));
        }
        else
        {
            StopCoroutine(Spawn(_shortWait));
        }
    }

    private void Awake()
    {
        float timeWaite = 2f;
        _shortWait = new WaitForSeconds(timeWaite);
    }

    private IEnumerator Spawn(WaitForSeconds shortWait)
    {
        while (_isSpawnStart )
        {
            Enemy enemy = Instantiate(_spawnedEnemy, transform.position, Quaternion.identity);
            enemy.transform.SetParent(_groupSpawnedEnemies);
            enemy.Initialize(_player, _destroyBase);

            ParticleSystem particle = Instantiate(_particleEnemyRespawnBase, transform.position, Quaternion.identity);
            particle.transform.SetParent(this.transform);

            yield return shortWait;
        }
    }
}
