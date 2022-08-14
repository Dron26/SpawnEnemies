using UnityEngine;

[RequireComponent(typeof(HashAnimationNamesDemo2))]
[RequireComponent(typeof(Animator))]

public class EnemyMovement : MonoBehaviour
{
    private HashAnimationNamesDemo2 _animBase;
    private Animator _animator;
    private float _walk;

    private void Awake()
    {
        gameObject.AddComponent<HashAnimationNamesDemo2>();
        _animBase = GetComponent<HashAnimationNamesDemo2>();
        _animator = GetComponent<Animator>();
        _walk = 1;
        _animator.SetFloat(_animBase.WalkOutHash, _walk);
    }
}