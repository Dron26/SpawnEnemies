using UnityEngine;

public class DestroyBase : MonoBehaviour
{
    private bool _isPlayerEnter;

    public bool isPlayerEnter()
    {
        return _isPlayerEnter;
    }

    private void Avake()
    {
        _isPlayerEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _isPlayerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _isPlayerEnter = false;
        }
    }
}
