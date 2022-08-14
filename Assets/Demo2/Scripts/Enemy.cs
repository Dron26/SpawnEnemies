using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DestroyBase _destroyBase;
    private Player  _player;
    private float _speed;
    private bool _isAlive;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void SetDestroyBase(DestroyBase destroyBase)
    {
        _destroyBase = destroyBase;
    }

    private void Update()
    {
        _isAlive = !_destroyBase.isPlayerEnter();

        if (_isAlive==false)
        {
            Destroy(gameObject);
        }
        else
        {
            _speed = 0.8f;
            transform.LookAt(_player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
    }
}
