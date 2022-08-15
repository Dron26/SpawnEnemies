using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyMovement : MonoBehaviour
{
    private Animator _animator;
    private float _walk;
    static int WalkOutHash;

    private void Awake()
    {
        _animator=GetComponent<Animator>();
           WalkOutHash = Animator.StringToHash("Forward");
        _walk = 1;
        _animator.SetFloat(AnimatorParameters.WalkOutHash, _walk);
    }
}