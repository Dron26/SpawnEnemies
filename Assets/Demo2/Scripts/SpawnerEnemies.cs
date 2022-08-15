using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _spawnedEnemy;
    [SerializeField] private DestroyBase _destroyBase;
    [SerializeField] private GameObject _enemies;

    private ParticleSystem _particleSpawn;
    private bool _isSpawnStart;
    private WaitForSeconds shortWait;
    private bool corountineWork;

    public void SetStart(bool isStart)
    {
        _isSpawnStart = isStart;
    }

    private void Awake()
    {       
        shortWait = new WaitForSeconds(2f);
        _particleSpawn = GetComponent<ParticleSystem>();
    }

    private void Update()
    { 
       if( _isSpawnStart & corountineWork==false)
        {
            StartCoroutine(Spawn(shortWait));
        }
    }

    private IEnumerator Spawn(WaitForSeconds shortWait)
    {
        corountineWork = true;

        Enemy enemy = Instantiate(_spawnedEnemy, transform.position, Quaternion.identity);
        enemy.transform.SetParent(_enemies.transform);
        enemy.Initialize(_player, _destroyBase);

        _particleSpawn.Play();
        yield return shortWait;
        corountineWork= false;
    }
}
