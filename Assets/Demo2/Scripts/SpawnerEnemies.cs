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
    private WaitForSeconds shortWait;
    private bool corountineWork;

    public void SetStart(bool isStart)
    {
        _isSpawnStart = isStart;
        if (_isSpawnStart)
        {
            StartCoroutine(Spawn(shortWait));
        }
        else
        {
            StopCoroutine(Spawn(shortWait));
        }
    }

    private void Awake()
    {
        shortWait = new WaitForSeconds(2f);
    }

    private IEnumerator Spawn(WaitForSeconds shortWait)
    {
        while (_isSpawnStart& corountineWork==false)
        {
            corountineWork = true;

            Enemy enemy = Instantiate(_spawnedEnemy, transform.position, Quaternion.identity);
            enemy.transform.SetParent(_groupSpawnedEnemies);
            enemy.Initialize(_player, _destroyBase);

            ParticleSystem particle = Instantiate(_particleEnemyRespawnBase, transform.position, Quaternion.identity);
            particle.transform.SetParent(this.transform);

            yield return shortWait;
            corountineWork = false;
        }

        yield return null; 
    }
}
