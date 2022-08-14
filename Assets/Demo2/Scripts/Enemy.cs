using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DestroyBase _destroyBase;
    private Player _player;
    private float _speed;
    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
    }

    public void Initialize(Player player, DestroyBase destroyBase)
    {
        _player = player;
        _destroyBase = destroyBase;
    }

    public void SetDestroy(bool isSetDestroy)
    {
        _isAlive = !isSetDestroy;
    }

    private void Update()
    {
        _speed = 0.8f;
        transform.LookAt(_player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
