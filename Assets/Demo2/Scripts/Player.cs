using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsAlive { get; private set; }

    private void Awake()
    {
        IsAlive = true;
    }
}