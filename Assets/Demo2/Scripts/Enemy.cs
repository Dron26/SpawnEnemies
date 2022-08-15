using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private float _speed;

    private void Start()
    {
        _speed = 0.8f;
    }

    public void Initialize(Player player, DestroyBase destroyBase)
    {
        _player = player;
    }

    private void Update()
    {
        transform.LookAt(_player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
