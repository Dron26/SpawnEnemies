using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private bool _isPlayerEnter;

    public bool isPlayerEnter()
    {
        return _isPlayerEnter;
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
